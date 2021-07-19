using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyBlog.Domain.UserAggregate;
using MyBlog.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyBlog.Api.Application.Queries
{
    public class UserQueryHandler : IRequestHandler<UserQuery, IDictionary<string, object>>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IDictionary<string, object>> Handle(UserQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId, cancellationToken);

            return user == null
                ? null
                : new Dictionary<string, object>()
                {
                    [nameof(User.Name)] = user.Name,
                    [nameof(User.Nickname)] = user.Nickname,
                    [nameof(User.Email)] = user.Email,
                    [nameof(User.Tel)] = user.Tel,
                    [nameof(User.IsAdmin)] = user.IsAdmin,
                };
        }
    }
}