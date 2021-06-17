using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation
{
    public enum UseCasesEnum
    {
        EFCreateCard = 1,
        EFDeleteCard = 2,
        EFUpdateCard = 3,

        EFAddImageToGym = 3,
        EFCreateGym = 4,
        EFDeleteGym = 5,
        EFUpdateGym = 6,
        
        EFUploadImage = 7,

        EFCreateMembership = 8,
        EFDeleteMembership = 9,
        EFUpdateMembership = 10,

        EFCreatePersonalTraining = 11,
        EFDeletePersonalTraining = 12,
        EFUpdatePersonalTraining = 13,

        EFCreateRole = 14,
        EFDeleteRole = 15,
        EFUpdateRole = 16,

        EFCreateTrainer = 17,
        EFDeleteTrainer = 18,
        EFUpdateTrainer = 19,

        EFCreateUser = 20,
        EFDeleteUser = 21,
        EFUpdateUser = 22,


        EFGetCards = 23,
        EFGetCardById = 24,

        EFGetGyms = 25,
        EFGetGymById = 26,

        EFGetMemberships = 27,
        EFGetMembershipById = 28,

        EFGetPersonalTrainings = 29,
        EFGetPersonalTrainingById = 30,

        EFGetRoles = 31,
        EFGetRoleById = 32,

        EFGetTrainers = 33,
        EFGetTrainerById = 34,

        EFGetUsers = 35,
        EFGetUserById = 36,

        EFCreateUserUseCase = 37,
        EFDeleteUserUseCase = 38,
        EFCreateTrainerUseCase = 39,
        EFDeleteTrainerUseCase = 40
    }
}
