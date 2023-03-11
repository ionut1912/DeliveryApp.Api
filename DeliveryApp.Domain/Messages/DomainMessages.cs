using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Messages
{
   public  static  class DomainMessages
    {
        public static class MenuItem
        {
            public static string MenuItemAddedSuccessfully() => "Menu item created successfully";
            public static string CanNotEditMenuItem(Guid id) => $"Menu item with id {id} can not be modified";
            public static string MenuItemEditedSuccessfully(Guid id) => $"Menu item with id {id} was modified";
            public static string NotFoundMenuItem(Guid id) => $"Menu item with id {id} was not found";
        }
        public  static class  Offer
        {

            public static string OfferAddedSuccessfully() => "Offer created successfully";
            public static string CanNotEditOffer(Guid id) => $"Offer with id {id} can not be modified";
            public static string OfferEditedSuccessfully(Guid id) => $"Offer with id {id} was modified";
            public static string NotFoundOffer(Guid id) => $"Offer with id {id} was not be found";
            
        }
        public  static class  Order
        {
            public static string OrderAddedSuccessfully() => "Order created successfully";
            public static string CanNotDeleteOrder(Guid id) => $"Order with id {id} can not be deleted";
            public static string OrderDeletedSuccessfully(Guid id) => $"Order with id {id} deleted successfully";
            public static string CanNotEditOrder(Guid id) => $"Order with id {id} can not be modified";
            public static string OrderEditedSuccessfully(Guid id) => $"Order with id {id}  was modified";
            public static string OrderNotFound(Guid id) => $"Order with id {id} was not found";

        }
        public  static class Photo
        {
            public  static string PhotoAddedSuccessfully()=> "Photo added successfully"
        }
    }
}
