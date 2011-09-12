using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Candidate.Core.Settings;
using Candidate.Core.Services;
using Ninject;

namespace Candidate.Infrustructure.Authentication {
    public class SettingsMembershipProvider : MembershipProvider {

        // TODO: Haven't found a way of injection this..?
        public ISettingsManager SettingsManager = new SettingsManager();
        public IHashService HashServices = new HashService();
        
        public override string ApplicationName {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline() {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline) {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email) {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName) {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user) {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password) {
            var currentSettings = SettingsManager.ReadSettings<UserSettings>();
            var user = currentSettings.Users.Where(_ => _.Login == username).SingleOrDefault();

            if (user != null && HashServices.ValidateMD5Hash(password, user.PasswordHash)) {
                return true;
            }

            return false;
        }
    }
}