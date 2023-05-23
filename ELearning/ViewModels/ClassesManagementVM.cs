using ELearning.Models.BusinessLogicLayer;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.ViewModels
{
    internal class ClassesManagementVM : BaseVM
    {
        private SpecializationsBLL specializationsBLL = new SpecializationsBLL();
        private ClassesBLL classesBLL = new ClassesBLL();
        private ClassMastersBLL classMastersBLL = new ClassMastersBLL();
        private TeachersBLL teachersBLL = new TeachersBLL();

        public ClassesManagementVM() { }

        public ObservableCollection<Specialization> Specializations 
        {
            get
            {
                return specializationsBLL.SpecializationsList;
            }

            set
            {
                specializationsBLL.SpecializationsList = value;
                NotifyPropertyChanged("Specializations");
            }
        }

        private ICommand addSpecializationCommand;
        public ICommand AddSpecializationCommand
        {
            get
            {
                if (addSpecializationCommand == null)
                {
                    addSpecializationCommand = new RelayCommand<string>(specializationsBLL.AddSpecialization);
                }
                return addSpecializationCommand;
            }
            set
            {
                addSpecializationCommand = value;
            }
        }

        private ICommand deleteSpecializationCommand;
        public ICommand DeleteSpecializationCommand
        {
            get
            {
                if (deleteSpecializationCommand == null)
                {
                    deleteSpecializationCommand = new RelayCommand<Specialization>(specializationsBLL.DeleteSpecialization);
                }
                return deleteSpecializationCommand;
            }
            set
            {
                deleteSpecializationCommand = value;
            }
        }

        public ObservableCollection<Class> Classes
        {
            get
            {
                return classesBLL.ClassesList;
            }

            set
            {
                classesBLL.ClassesList = value;
                NotifyPropertyChanged("Classes");
            }
        }

        private ICommand addClassCommand;
        public ICommand AddClassCommand
        {
            get
            {
                if (addClassCommand == null)
                {
                    addClassCommand = new RelayCommand<Class>(classesBLL.AddClass);
                }
                return addClassCommand;
            }
            set
            {
                addClassCommand = value;
            }
        }

        private ICommand deleteClassCommand;
        public ICommand DeleteClassCommand
        {
            get
            {
                if (deleteClassCommand == null)
                {
                    deleteClassCommand = new RelayCommand<Class>(classesBLL.DeleteClass);
                }
                return deleteClassCommand;
            }
            set
            {
                deleteSpecializationCommand = value;
            }
        }

        public ObservableCollection<ClassMaster> ClassMasters
        {
            get
            {
                return classMastersBLL.ClassMastersList;
            }

            set
            {
                classMastersBLL.ClassMastersList = value;
                NotifyPropertyChanged("ClassMasters");
            }
        }

        private ICommand addClassMasterCommand;
        public ICommand AddClassMasterCommand
        {
            get
            {
                if (addClassMasterCommand == null)
                {
                    addClassMasterCommand = new RelayCommand<ClassMaster>(classMastersBLL.AddClassMaster);
                }
                return addClassMasterCommand;
            }
            set
            {
                addClassMasterCommand = value;
            }
        }

        private ICommand deleteClassMasterCommand;
        public ICommand DeleteClassMasterCommand
        {
            get
            {
                if (deleteClassMasterCommand == null)
                {
                    deleteClassMasterCommand = new RelayCommand<ClassMaster>(classMastersBLL.DeleteClassMaster);
                }
                return deleteClassMasterCommand;
            }
            set
            {
                deleteClassMasterCommand = value;
            }
        }
        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                return teachersBLL.TeachersList;
            }

            set
            {
                teachersBLL.TeachersList = value;
                NotifyPropertyChanged("Teachers");
            }
        }
    }
}
