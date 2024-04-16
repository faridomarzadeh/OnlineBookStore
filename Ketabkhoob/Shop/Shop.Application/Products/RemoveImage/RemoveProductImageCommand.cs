﻿using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveProductImageCommand(long ProductId,long ImageId):IBaseCommand;
}
