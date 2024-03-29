﻿namespace DeliveryApp.Domain.Messages;

public static class DomainMessagesEn
{
    public static class MenuItem
    {
        public static string MenuItemAddedSuccessfully = "Menu item created successfully";


        public static string CanNotEditMenuItem(Guid id)
        {
            return $"Menu item with id {id} can not be modified";
        }

        public static string MenuItemEditedSuccessfully(Guid id)
        {
            return $"Menu item with id {id} was modified";
        }

        public static string NotFoundMenuItem(Guid id)
        {
            return $"Menu item with id {id} was not found";
        }
    }

    public static class Offer
    {
        public static string OfferAddedSuccessfully = "Offer created successfully";

        public static string CanNotEditOffer(Guid id)
        {
            return $"Offer with id {id} can not be modified";
        }

        public static string OfferEditedSuccessfully(Guid id)
        {
            return $"Offer with id {id} was modified";
        }

        public static string NotFoundOffer(Guid id)
        {
            return $"Offer with id {id} was not be found";
        }
    }

    public static class Order
    {
        public static string OrderAddedSuccessfully => "Order created successfully";

        public static string CanNotDeleteOrder(Guid id)
        {
            return $"Order with id {id} can not be deleted";
        }

        public static string OrderDeletedSuccessfully(Guid id)
        {
            return $"Order with id {id} deleted successfully";
        }

        public static string CanNotEditOrder(Guid id)
        {
            return $"Order with id {id} can not be modified";
        }

        public static string OrderEditedSuccessfully(Guid id)
        {
            return $"Order with id {id}  was modified";
        }

        public static string OrderNotFound(Guid id)
        {
            return $"Order with id {id} was not found";
        }
    }

    public static class Photo
    {
        public static string PhotoAddedSuccessfully => "Photo added successfully";

        public static string CanNotDeletePhoto(string id)
        {
            return $"Photo with id {id} can not be deleted";
        }

        public static string PhotoDeletedSuccessfully(string id)
        {
            return $"Photo  with id {id} deleted successfully";
        }

        public static string CanNotSetMainPhoto(string id)
        {
            return $"Photo with id {id} can not be set as main photo";
        }

        public static string PhotoSetAsMain(string id)
        {
            return $"Photo with id {id} was set as main";
        }

        public static string CanNotModifyMainPhoto()
        {
            return "Main photo can not be modified";
        }

        public static string MainPhotoModified()
        {
            return "Main photo was modified";
        }
    }

    public static class PhotoForMenuItem
    {
        public static string PhotoAddedSuccessfully => "Photo added successfully";

        public static string CanNotDeletePhoto(string id)
        {
            return $"Photo with id {id} can not be deleted";
        }

        public static string PhotoDeletedSuccessfully(string id)
        {
            return $"Photo with id {id} deleted successfully";
        }

        public static string CanNotSetAsMainPhoto(string id)
        {
            return $"Photo with id {id} can not be set as main photo";
        }

        public static string PhotoSetAsMain(string id)
        {
            return $"Photo with id {id} was set as main";
        }
    }

    public static class PhotoForRestaurant
    {
        public static string PhotoAddedSuccessfully => "Photo for restaurant added successfully";

        public static string CanNotDeletePhoto(string id)
        {
            return $"Photo with id {id} can not be deleted";
        }

        public static string PhotoDeletedSuccessfully(string id)
        {
            return $"Photo with id {id} deleted successfully";
        }

        public static string CanNotSetAsMainPhoto(string id)
        {
            return $"Photo with id {id} can not be set as main photo";
        }

        public static string PhotoSetAsMain(string id)
        {
            return $"Photo with id {id} was set as main";
        }
    }

    public static class Restaurant
    {
        public static string RestaurantAddedSuccessfully => "Restaurant added successfully";

        public static string CanNotDeleteRestaurant(Guid id)
        {
            return $"Restaurant with id {id} can not be deleted";
        }

        public static string RestaurantDeletedSuccessfully(Guid id)
        {
            return $"Restaurant with id  {id} deleted successfully";
        }

        public static string CanNotEditRestaurant(Guid id)
        {
            return $"Restaurant with id {id} can not be modified";
        }

        public static string RestaurantEditedSuccessfully(Guid id)
        {
            return $"Restaurant with id {id} modified successfully";
        }

        public static string NotFoundRestaurant(Guid id)
        {
            return $"Restaurant with id {id}  was not found";
        }
    }

    public static class UserConfig
    {
        public static string UserConfigAddedSuccessfully => "Config added successfully";

        public static string NotFoundUserConfig(Guid id)
        {
            return $"Config with id {id} does not exists";
        }

        public static string CanNotDeleteConfig(Guid id)
        {
            return $"Config with id {id} can not be deleted";
        }

        public static string ConfigDeletedSuccessfully(Guid id)
        {
            return $"Config with id {id} deleted successfully";
        }

        public static string ConfigEditedSuccessfully(Guid id)
        {
            return $"Config with id {id} updated successfully";
        }
    }

    public static class Account
    {
        public static string ProblemCreatingAccount => "There are issues creating your account";
        public static string AccountCreatedSuccessfully => "Account was created successfully";
        public static string CanNotModifyAddress => "User address can not be modified";
        public static string AddressModified => "User address successfully modified";
        public static string CodeSentSuccessfully => "Code was sent via email.Please check your inbox";
        public static string IssuesResetingPassword => "There are issues reseting your password";
        public static string PasswordResetedSuccessfully => "Password was successfully reseted";
    }

    public static class ReviewForMenuItem
    {
        public static string ReviewCreated => "Review created successfully!";

        public static string CanNotEditReview(Guid id, Guid menuItemId)
        {
            return $"Can not edit review {id} for menuItem {menuItemId}";
        }

        public static string ReviewEdited(Guid id)
        {
            return $"Review with id {id} was successfully modified";
        }

        public static string NotFound(Guid id)
        {
            return $"Review with id {id} can not be found";
        }

        public static string CanNoDeleteReview(Guid id)
        {
            return $"Can not delete review {id}";
        }

        public static string ReviewDeleted(Guid id)
        {
            return $"Review with id {id} was successfully deleted";
        }
    }

    public static class ReviewForRestaurant
    {
        public static string ReviewCreated => "Review created successfully!";

        public static string CanNotEditReview(Guid id, Guid restaurantId)
        {
            return $"Can not edit review {id} for restaurant {restaurantId}";
        }

        public static string ReviewEdited(Guid id)
        {
            return $"Review with id {id} was successfully modified";
        }

        public static string CanNoDeleteReview(Guid id)
        {
            return $"Can not delete review with id {id}";
        }

        public static string NotFound(Guid id)
        {
            return $"Review with id {id} can not be found";
        }

        public static string ReviewDeleted(Guid id)
        {
            return $"Review with id {id} was successfully deleted";
        }
    }
}