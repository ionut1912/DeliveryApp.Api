using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;
using DeliveryApp.ExternalServices.MailSending;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class
    ForgotPasswordGenerateCodeCommandHandler : ICommandHandler<ForgotPasswordGenerateCodeCommand, ResultT<JsonResponse>>
{
    private readonly IMailService _mailService;

    public ForgotPasswordGenerateCodeCommandHandler(IMailService mailService)
    {
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }

    public async Task<ResultT<JsonResponse>> Handle(ForgotPasswordGenerateCodeCommand request,
        CancellationToken cancellationToken)
    {
        var mailRequest = new MailRequest
        {
            ToEmail = request.Request.Email,
            Subject = "Your request to reset your password was received",
            Body = $"We received your request to reset your password.Here is your reset password code: {GenerateCode()}"
        };
        await _mailService.SendEmailAsync(mailRequest);
        var jsonResponse = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.Account.CodeSentSuccessfully
                : DomainMessagesRo.Account.CodeSentSuccessfully
        };
        return ResultT<JsonResponse>.Success(jsonResponse);
    }

    private static string GenerateCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}