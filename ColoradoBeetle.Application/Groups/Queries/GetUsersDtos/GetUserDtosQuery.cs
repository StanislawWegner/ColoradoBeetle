﻿using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersDtos {
    public class GetUserDtosQuery : IRequest<UsersInGroupVm>{
        public int GroupId { get; set; }
    }
}
