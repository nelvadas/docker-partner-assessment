﻿using System;
using System.Collections.Generic;

namespace Models
{
    public partial class CustomerAddress
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address Address { get; set; }
        public Customer Customer { get; set; }
    }
}
