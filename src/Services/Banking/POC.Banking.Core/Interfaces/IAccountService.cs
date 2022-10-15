﻿using POC.Banking.Core.Entities;

namespace POC.Banking.Core.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAccounts();

}