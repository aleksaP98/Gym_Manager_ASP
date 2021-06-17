using Gym_Management.Api.Core;
using Gym_Manager.Application;
using Gym_Manager.Application.Commands.Card;
using Gym_Manager.Application.Commands.Gym;
using Gym_Manager.Application.Commands.Image;
using Gym_Manager.Application.Commands.Membership;
using Gym_Manager.Application.Commands.PersonalTraining;
using Gym_Manager.Application.Commands.Roles;
using Gym_Manager.Application.Commands.Trainer;
using Gym_Manager.Application.Commands.UseCase;
using Gym_Manager.Application.Commands.User;
using Gym_Manager.Application.Queries.Card;
using Gym_Manager.Application.Queries.Gym;
using Gym_Manager.Application.Queries.Membership;
using Gym_Manager.Application.Queries.PersonalTraining;
using Gym_Manager.Application.Queries.Role;
using Gym_Manager.Application.Queries.Trainer;
using Gym_Manager.Application.Queries.User;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Commands.Card;
using Gym_Manager.Implementation.Commands.Gym;
using Gym_Manager.Implementation.Commands.Image;
using Gym_Manager.Implementation.Commands.Membership;
using Gym_Manager.Implementation.Commands.PersonalTraining;
using Gym_Manager.Implementation.Commands.Roles;
using Gym_Manager.Implementation.Commands.Trainer;
using Gym_Manager.Implementation.Commands.UseCase;
using Gym_Manager.Implementation.Commands.User;
using Gym_Manager.Implementation.Queries.Card;
using Gym_Manager.Implementation.Queries.Gym;
using Gym_Manager.Implementation.Queries.Membership;
using Gym_Manager.Implementation.Queries.PersonalTraining;
using Gym_Manager.Implementation.Queries.Role;
using Gym_Manager.Implementation.Queries.Trainer;
using Gym_Manager.Implementation.Queries.User;
using Gym_Manager.Implementation.Validators.Card;
using Gym_Manager.Implementation.Validators.Gym;
using Gym_Manager.Implementation.Validators.Image;
using Gym_Manager.Implementation.Validators.Membership;
using Gym_Manager.Implementation.Validators.PersonalTraining;
using Gym_Manager.Implementation.Validators.Role;
using Gym_Manager.Implementation.Validators.Trainer;
using Gym_Manager.Implementation.Validators.UseCase;
using Gym_Manager.Implementation.Validators.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Api.Core
{
    public static class ContainerExtenstions
    {
        public static void AddDependencies(this IServiceCollection services){

            services.AddTransient<ICreateMembershipCommand, EFCreateMembershipCommand>(); 
            services.AddTransient<IUpdateMembershipCommand, EFUpdateMembershipCommand>();
            services.AddTransient<IDeleteMembershipCommand, EFDeleteMembershipCommand>();
            services.AddTransient<IGetMembershipsQuery, EFGetMembershipsQuery>();
            services.AddTransient<IGetMembershipByIdQuery, EFGetMembershipByIdQuery>();
            services.AddTransient<ICreateCardCommand, EFCreateCardCommand>();
            services.AddTransient<IUpdateCardCommand, EFUpdateCardCommand>();
            services.AddTransient<IDeleteCardCommand, EFDeleteCardCommand>();
            services.AddTransient<IGetCardsQuery, EFGetCardsQuery>();
            services.AddTransient<IGetCardByIdQuery, EFGetCardByIdQuery>();
            services.AddTransient<IUploadImageCommand, EFUploadImageCommand>();
            services.AddTransient<ICreateGymCommand, EFCreateGymCommand>();
            services.AddTransient<IUpdateGymCommand, EFUpdateGymCommand>();
            services.AddTransient<IDeleteGymCommand, EFDeleteGymCommand>();
            services.AddTransient<IAddImagesToGymCommand, EFAddImagesToGymCommand>();
            services.AddTransient<IGetGymsQuery, EFGetGymsQuery>();
            services.AddTransient<IGetGymByIdQuery, EFGetGymByIdQuery>();
            services.AddTransient<ICreateUserCommand, EFCreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            services.AddTransient<IGetUsersQuery, EFGetUsersQuery>();
            services.AddTransient<IGetUserByIdQuery, EFGetUserByIdQuery>();
            services.AddTransient<ICreateTrainerCommand, EFCreateTrainerCommand>();
            services.AddTransient<IUpdateTrainerCommand, EFUpdateTrainerCommand>();
            services.AddTransient<IDeleteTrainerCommand, EFDeleteTrainerCommand>();
            services.AddTransient<IGetTrainersQuery, EFGetTrainersQuery>();
            services.AddTransient<IGetTrainerByIdQuery, EFGetTrainerByIdQuery>();
            services.AddTransient<ICreateRoleCommand, EFCreateRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EFUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            services.AddTransient<IGetRolesQuery, EFGetRolesQuery>();
            services.AddTransient<IGetRoleByIdQuery, EFGetRoleByIdQuery>();
            services.AddTransient<ICreatePersonalTrainingCommand, EFCreatePersonalTrainingCommand>();
            services.AddTransient<IUpdatePersonalTrainingCommand, EFUpdatePersonalTrainingCommand>();
            services.AddTransient<IDeletePersonalTrainingCommand, EFDeletePersonalTrainingCommand>();
            services.AddTransient<IGetPersonalTrainingsQuery, EFGetPersonalTrainingsQuery>();
            services.AddTransient<IGetPersonalTrainingByIdQuery, EFGetPersonalTrainingByIdQuery>();
            services.AddTransient<ICreateUserUseCaseCommand, EFCreateUserUseCaseCommand>();
            services.AddTransient<ICreateTrainerUseCaseCommand, EFCreateTrainerUseCaseCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, EFDeleteUserUseCaseCommand>();
            services.AddTransient<IDeleteTrainerUseCaseCommand, EFDeleteTrainerUseCaseCommand>();
            services.AddTransient<MembershipValidator>();
            services.AddTransient<CreateCardValidator>();
            services.AddTransient<ChechCardAuthValidator>();
            services.AddTransient<UpdateCardValidator>();
            services.AddTransient<CreateGymValidator>();
            services.AddTransient<UpdateGymValidator>();
            services.AddTransient<ImageValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateTrainerValidator>();
            services.AddTransient<UpdateTrainerValidator>();
            services.AddTransient<RoleValidator>();
            services.AddTransient<CreatePersonalTrainingValidator>();
            services.AddTransient<UpdatePersonalTrainingValidator>();
            services.AddTransient<UserUseCaseValidator>();
            services.AddTransient<TrainerUseCaseValidator>();
        }
        public static void AddIApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JWTActor>(actorString);

                return actor;

            });
        }
        public static void AddJwt(this IServiceCollection services,AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<GymManagerContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
