namespace BullsAndCows.Wcf
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using BullsAndCows.Wcf.Models;

    [ServiceContract]
    public interface IUserInfoService
    {

        [OperationContract]
        //[WebGet(UriTemplate = "/users")]
        IQueryable<UserShortInfoModel> GetUsers();

        
        [OperationContract]
        //[WebGet(UriTemplate = "/users")]
        IQueryable<UserShortInfoModel> GetUsersOnPage(int page);

        [OperationContract]
        //[WebGet(UriTemplate = "/users/id")]
        UserDetailedInfoModel GetUserById(string id);
    }
}