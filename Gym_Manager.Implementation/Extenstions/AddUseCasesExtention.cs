using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Extenstions
{
    public static class AddUseCasesExtention
    {
        public static void AddUseCasesForUser(this User user)
        {
            var list = new List<UserUseCase>();

            if (user.RoleId == 1)
            {
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreateRole });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeleteRole });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdateRole });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetRoleById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetRoles });      

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreateUser });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeleteUser });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdateUser });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetUserById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetUsers });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreateCard });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdateCard });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeleteCard });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetCardById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetCards });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreateGym });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdateGym });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeleteGym });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetGymById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetGyms });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUploadImage });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreateMembership });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdateMembership });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeleteMembership });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetMembershipById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetMemberships });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreatePersonalTraining });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdatePersonalTraining });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeletePersonalTraining });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetPersonalTrainingById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetPersonalTrainings });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreateTrainer });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdateTrainer });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeleteTrainer });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetTrainerById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetTrainers });
                

            }
            else if (user.RoleId == 2)
            {
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetGymById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetGyms });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetMembershipById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetMemberships });

                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFCreatePersonalTraining });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFUpdatePersonalTraining });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFDeletePersonalTraining });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetPersonalTrainingById });
                list.Add(new UserUseCase { UseCaseId = (int)UseCasesEnum.EFGetPersonalTrainings });

            }

            user.UserUseCases = list;
        }
        public static void AddUseCasesForTrainer(this Domain.Trainer trainer)
        {
            var list = new List<TrainerUseCase>();
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFGetGymById });
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFGetGyms });

            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFGetMembershipById });
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFGetMemberships });

            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFCreatePersonalTraining });
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFUpdatePersonalTraining });
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFDeletePersonalTraining });
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFGetPersonalTrainingById });
            list.Add(new TrainerUseCase { UseCaseId = (int)UseCasesEnum.EFGetPersonalTrainings });

            trainer.TrainerUseCases = list;

        }
    }
    
}
