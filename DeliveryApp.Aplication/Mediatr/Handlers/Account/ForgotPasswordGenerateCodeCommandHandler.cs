using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;
using DeliveryApp.ExternalServices.MailSending;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class
    ForgotPasswordGenerateCodeCommandHandler : ICommandHandler<ForgotPasswordGenerateCodeCommand, ResultT<JsonResponse>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMailService _mailService;
    private readonly IUnitOfWork _unitOfWork;

    public ForgotPasswordGenerateCodeCommandHandler(IAccountRepository accountRepository, IMailService mailService,
        IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(ForgotPasswordGenerateCodeCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _accountRepository.GenerateResetPasswordCode(request.Request.Email, cancellationToken);

        var mailRequest = new MailRequest
        {
            ToEmail = request.Request.Email,
            Subject = "Your request to reset your password was received",
            Body = $"We received your request to reset your password.Here is your reset password code: {result}"
        };
        await _mailService.SendEmailAsync(mailRequest);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponse = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.Account.CodeSentSuccessfully
                : DomainMessagesRo.Account.CodeSentSuccessfully
        };
        return ResultT<JsonResponse>.Success(jsonResponse);
    }
}