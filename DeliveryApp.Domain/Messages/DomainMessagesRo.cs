namespace DeliveryApp.Domain.Messages;

public static class DomainMessagesRo
{
    public static class Order
    {
        public static string OrderAddedSuccessfully => "Comanda a fost creata cu success";

        public static string CanNotEditOrder(Guid id)
        {
            return $"Comanda cu  id-ul {id} nu poate fi modificata";
        }

        public static string OrderEditedSuccessfully(Guid id)
        {
            return $"Comanda cu id-ul {id}  a fost modificata";
        }
    }


    public static class UserConfig
    {
        public static string UserConfigAddedSuccessfully => "Config-ul a fost adaugat cu success!";

        public static string NotFoundUserConfig(Guid id)
        {
            return $"Config cu id-ul {id}  nu exista";
        }

        public static string ConfigEditedSuccessfully(Guid id)
        {
            return $"Config-ul cu id-ul {id} a fost modificat";
        }
    }

    public static class Account
    {
        public static string ProblemCreatingAccount => "Sunt probleme cu crearea contului";
        public static string AccountCreatedSuccessfully => "Contul a fost creat cu success";
        public static string CanNotModifyAddress => "Adresa utilizatorului nu poate fi modificata";
        public static string AddressModified => "Adresa utilizatorului a fost modificata cu success";
    }

    public static class ReviewForMenuItem
    {
        public static string ReviewCreated => "Review-ul a fost adaugat cu success!";

        public static string CanNotEditReview(Guid id, Guid menuItemId)
        {
            return $"Review-ul cu id-ul {id} pentru felul de mancare cu id-ul {menuItemId} nu poate fi modificat";
        }

        public static string ReviewEdited(Guid id)
        {
            return $"Review-ul cu id-ul {id} a fost modificat cu success";
        }

        public static string NotFound(Guid id)
        {
            return $"Review-ul cu id-ul {id} nu a fost gasit";
        }

        public static string CanNoDeleteReview(Guid id)
        {
            return $"Review-ul cu id-ul {id} nu poate fi sters";
        }

        public static string ReviewDeleted(Guid id)
        {
            return $"Review cu id-ul {id} a fost sters";
        }
    }

    public static class ReviewForRestaurant
    {
        public static string ReviewCreated => "Review-ul a fost creat cu success!";

        public static string CanNotEditReview(Guid id, Guid restaurantId)
        {
            return $"Review-ul cu id-ul {id} pentru restaurant-ul {restaurantId} nu poate fi modificat";
        }

        public static string ReviewEdited(Guid id)
        {
            return $"Review-ul cu id-ul {id} a fost modificat cu success";
        }

        public static string CanNoDeleteReview(Guid id)
        {
            return $"Review-ul cu id-ul {id} nu poate fi sters";
        }

        public static string NotFound(Guid id)
        {
            return $"Review-ul cu  id-ul {id} nu a fost gasit";
        }

        public static string ReviewDeleted(Guid id)
        {
            return $"Review cu id-ul {id} a fost sters";
        }
    }
}