using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Runtime.CompilerServices;
using MyForm.Annotations;

namespace MyForm.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Status : PropertyChangedNotifier
    {
        /// <summary>
        /// 
        /// </summary>
        public Status()
        {
            Initialize();
        }
        
        public DateTime LastParse
        {
            get => _lastParse;
            set => SetField(ref _lastParse, value, nameof(LastParse));
        }

        public DateTime NextParse 
        {
            get => _nextParse;
            set => SetField(ref _nextParse, value, nameof(NextParse));
        }

        public int ParseErrors
        {
            get => _parseErrors;
            set => SetField(ref _parseErrors, value, nameof(ParseErrors));
        }

        public int SerialNumber
        {
            get => _serialNumber;
            set => SetField(ref _serialNumber, value, nameof(SerialNumber));
        }

        public LicenseStatuses LicenseStatus
        {
            get => _licenseStatus;
            set => SetField(ref _licenseStatus, value, nameof(LicenseStatus));
        }

        public DateTime LicenseExpirationDate
        {
            get => _licenseExpirationDate;
            set => SetField(ref _licenseExpirationDate, value, nameof(LicenseExpirationDate));
        }

        public ServiceErrors ServiceError
        {
            get => _serviceError;
            set => SetField(ref _serviceError, value, nameof(ServiceError));
        }

        public enum ServiceErrors
        {
            LicenseInvalid,
            LostConnection,
            UnknownErrors
        }

        public enum LicenseStatuses
        {
            Valid,
            Invalid
        }

        #region Implementation
        private DateTime _lastParse;
        private DateTime _nextParse;
        private int _parseErrors;
        private int _serialNumber;
        private LicenseStatuses _licenseStatus;
        private DateTime _licenseExpirationDate;
        private ServiceErrors _serviceError;

        private readonly Random _random = new Random();

        private void Initialize()
        {
            LastParse = DateTime.Now;
            NextParse = LastParse + TimeSpan.FromHours(8);
            ParseErrors = _random.Next(1, 10);

            for (var i = 0; i < 9; i++)
            {
                SerialNumber += _random.Next(0, 9) * (10 * (i + 1));
            }

            Enum.TryParse(_random.Next(0, Enum.GetNames(typeof(LicenseStatuses)).Length).ToString(),
                out LicenseStatuses licenseStatus);
            LicenseStatus = licenseStatus;

            LicenseExpirationDate = LastParse.AddDays(_random.Next(1, 365));

            Enum.TryParse(_random.Next(0, Enum.GetNames(typeof(ServiceErrors)).Length).ToString(),
                out ServiceErrors serviceError);
            ServiceError = serviceError;
        }
        #endregion
    }
}