using ELearning.Models.Data;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;
using System.Windows;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class SpecializationsBLL
    {
        public ObservableCollection<Specialization> SpecializationsList { get; set; }
        private SpecializationRepository SpecializationsRepository;

        public SpecializationsBLL()
        {
            SpecializationsRepository = new SpecializationRepository(DataService.context);
            SpecializationsList = new ObservableCollection<Specialization>(SpecializationsRepository.GetAllSpecializations());
            SpecializationsRepository.GetAll();
        }

        public void AddSpecialization(string specializationName)
        {
            if (!specializationName.IsNullOrEmpty())
            {
                if (SpecializationsRepository.FindByName(specializationName) == null)
                {
                    SpecializationsRepository.InsertSpecialization(specializationName);
                    SpecializationsList.Add(SpecializationsRepository.FindByName(specializationName));
                }
                else
                {
                    MessageBox.Show("This Specialization already exist!");
                }
            }
            else
            {
                MessageBox.Show("Please add required arguments!");
            }
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            if (specialization == null)
            {
                MessageBox.Show("You didn't select any specialization!");
                return;
            }

            SpecializationsList.Remove(specialization);
            SpecializationsRepository.DeleteSpecialization(specialization);
        }
    }
}
