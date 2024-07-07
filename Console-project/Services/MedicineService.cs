using Console_project.Exceptions;
using Console_project.Models;

namespace Console_project.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine)
        {
            bool hasCategory = false;


            foreach (var category in DB.categories)
            {
                if (category.Id == medicine.Id)
                {

                    hasCategory = true;
                    break;
                }

            }
            if (hasCategory)
            {

                Array.Resize(ref DB.medicines, DB.medicines.Length + 1);

                DB.medicines[DB.medicines.Length - 1] = medicine;
            }
            else
            {
                throw new NotFoundException("Category not found.");
            }

        }

        public void GetAllMedicine()
        {
            foreach (var medicine in DB.medicines)
            {
                Console.WriteLine($"ID: {medicine.Id}, Name: {medicine.Name}, Price: {medicine.Price}, Category ID: {medicine.CategoryId}, User ID: {medicine.UserId}, Created Date: {medicine.CreatedDate}");
            }
        }

        public Medicine GetMedicineById(int id)
        {
            Medicine foundMedicine = null;

            foreach (var medicine in DB.medicines)
            {
                if (medicine.Id == id)
                {
                    foundMedicine = medicine;
                    break;
                }
            }

            if (foundMedicine != null)
            {
                Console.WriteLine(foundMedicine);
                return foundMedicine;

            }
            else
            {
                throw new NotFoundException("Medicine not found.");

            }

        }

        public Medicine GetMedicineByName(string name)
        {
            Medicine foundMedicine = null;
            foreach (var medicine in DB.medicines)
            {
                if (medicine.Name == name)
                {
                    foundMedicine = medicine;
                    Console.WriteLine(medicine);
                }
            }

            if (foundMedicine != null)
            {
                Console.WriteLine(foundMedicine);
                return foundMedicine;
            }
            else
            {
                throw new NotFoundException($"Medicine with name: {name} not found.");
            }
        }

        public Medicine GetMedicineByCategory(int id)
        {
            Medicine foundMedicine = null;
            foreach (var medicine in DB.medicines)
            {
                if (medicine != null)
                {
                    if (medicine.CategoryId == id)
                    {
                        foundMedicine = medicine;
                    }
                }

            }

            if (foundMedicine != null)
            {
                Console.WriteLine(foundMedicine);
                return foundMedicine;
            }
            else
            {
                throw new NotFoundException($"Medicine witd ID: {id} not found");

            }
        }

        public void RemoveMedicine(int elementId)
        {
            Medicine[] tempArray = new Medicine[DB.medicines.Length - 1];
            int idx = 0;

            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].Id != elementId)
                {
                    tempArray[idx] = DB.medicines[i];
                    idx++;

                }

            }
            DB.medicines = tempArray;

        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            int tempIdx = -1;

            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].Id == id)
                {
                    tempIdx = i;
                    break;
                }
            }
            if (tempIdx >= 0)
            {
                DB.medicines[tempIdx] = updatedMedicine;
            }
            else
            {
                throw new NotFoundException($"Medicine data with ID--{id} doen't exsist.");
            }

        }
    }
}
