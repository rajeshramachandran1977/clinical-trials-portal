using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.Utilities
{
    public enum ResponseType
    {
        Success = 1,
        PartiallySuccess = 61,
        Error = 11,
        Warning = 21,
        Exception = 31,
        Validation = 41,
        DbException = 51
    }

    #region eAuditChangeType
    public enum eAuditChangeType
    {
        Insert = 1,

        Update = 2,

        Delete = 3
    }
    #endregion

    #region eDocumentType
    public enum eDocumentType
    {
        Regulatory = 0,

        Budget = 1,

        SubmissionSupport = 2,

        ProtocolSupport = 3
    }
    #endregion

    #region eDocumentStatus
    public enum eDocumentStatus
    {
        PendingReview = 0,
        Approved = 1
    }
    #endregion

    #region eDocumentSubType
    public enum eDocumentSubType
    {
        CV = 0,

        Draft = 1,

        AdditionalDocuments = 2,

        ProtocolDocument = 3
    }
    #endregion

    #region eSecurityLogEntryType
    public enum eSecurityLogEntryType : int
    {
        SystemLogin = 1,

        APILogin = 2,

        SystemLogoff = 3,

        SystemExit = 4,

        APIExit = 5,

        ForgotPasswordRequest = 6,

        ForgotPasswordAttempt = 7,

        IncorrectPasswordAttempt = 8,

        PasswordChange = 9,
    }
    #endregion

    
}
