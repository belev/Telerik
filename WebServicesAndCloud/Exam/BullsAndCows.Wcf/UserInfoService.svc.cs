namespace BullsAndCows.Wcf
{
    using System;
    using System.Linq;
    using Exam.Data;
    using BullsAndCows.Wcf.Models;

    public class UserInfoService : IUserInfoService
    {
        private const int USERS_TO_TAKE_COUNT = 10;

        public IQueryable<UserShortInfoModel> GetUsers()
        {
            var data = new BullsAndCowsData(new BullsAndCowsContext());

            var users = data.Users
                            .All()
                            .OrderBy(u => u.UserName)
                            .Take(USERS_TO_TAKE_COUNT)
                            .Select(UserShortInfoModel.FromUser);

            return users;
        }

        public UserDetailedInfoModel GetUserById(string ID)
        {
            var data = new BullsAndCowsData(new BullsAndCowsContext());
            var user = data.Users
                           .All()
                           .Where(u => u.Id == ID)
                           .Select(UserDetailedInfoModel.FromUser)
                           .FirstOrDefault();

            return user;
        }

        public IQueryable<UserShortInfoModel> GetUsersOnPage(int page)
        {
            var data = new BullsAndCowsData(new BullsAndCowsContext());

            var users = data.Users
                            .All()
                            .OrderBy(u => u.UserName)
                            .Skip(page * USERS_TO_TAKE_COUNT)
                            .Take(USERS_TO_TAKE_COUNT)
                            .Select(UserShortInfoModel.FromUser);

            return users;
        }
    }
}