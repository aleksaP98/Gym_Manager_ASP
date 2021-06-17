using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class TrainerUseCaseDto
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int UseCaseId { get; set; }
    }
}
