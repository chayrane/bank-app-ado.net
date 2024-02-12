CREATE TABLE Bank (
    BankId NVARCHAR(50) PRIMARY KEY,
    BankName NVARCHAR(100) NOT NULL,
    IfscCode NVARCHAR(20) NOT NULL,
    CreatedOn DATETIME NOT NULL,
    DefaultRtgsChargeSameBank DECIMAL(10, 2) NOT NULL,
    DefaultImpsChargeSameBank DECIMAL(10, 2) NOT NULL,
    DefaultRtgsChargeOtherBank DECIMAL(10, 2) NOT NULL,
    DefaultImpsChargeOtherBank DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Account (
    AccountId NVARCHAR(50) PRIMARY KEY,
    AccountHolderName NVARCHAR(100) NOT NULL,
    Pin INT NOT NULL,
    BankId NVARCHAR(50) NOT NULL,
    Balance DECIMAL(15, 2) NOT NULL,
    FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);

CREATE TABLE Transactions (
    TransactionId NVARCHAR(50) PRIMARY KEY,
    TransactionType INT NOT NULL,
    TransactionDateTime DATETIME,
    FromBankId NVARCHAR(50) NOT NULL,
    FromAccountId NVARCHAR(50) NOT NULL,
    ToBankId NVARCHAR(50) NOT NULL,
    ToAccountId NVARCHAR(50) NOT NULL,
    TransactionAmount DECIMAL(15, 2) NOT NULL,
    Balance DECIMAL(15, 2) NOT NULL,
    FOREIGN KEY (FromAccountId) REFERENCES Account(AccountId),
    FOREIGN KEY (ToAccountId) REFERENCES Account(AccountId),
    FOREIGN KEY (FromBankId) REFERENCES Bank(BankId)
    FOREIGN KEY (ToBankId) REFERENCES Bank(BankId)
);

CREATE TABLE AcceptedCurrency (
    BankId NVARCHAR(50) NOT NULL,
    Currency NVARCHAR(10) NOT NULL,
    ExchangeRate DECIMAL(15, 6) NOT NULL,
    PRIMARY KEY (BankId, Currency),
    FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);