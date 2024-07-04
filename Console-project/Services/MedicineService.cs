using Console_project.Models;

namespace Console_project.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine)
        {
            Array.Resize(ref DB.medicineData, DB.medicineData.Length + 1);

            DB.medicineData[DB.medicineData.Length - 1] = medicine;
        }

        public Medicine[] GetAllMedicine()
        {
            return DB.medicineData;
        }

        public Medicine GetMedicineById(int id)
        {
            foreach (var medItem in DB.medicineData)
            {
                if (medItem.Id == id)
                {
                    return medItem;
                }
            }
            return null;
        }

        public Medicine GetMedicineByName(string name)
        {
            foreach (var medItem in DB.medicineData)
            {
                if (medItem.Name == name)
                {
                    return medItem;
                }
            }
            return null;
        }

        public Medicine GetMedicineByCategory(int id)
        {
            foreach (var medItem in DB.medicineData)
            {
                if (medItem.CategoryId == id)
                {
                    return medItem;
                }
            }
            return null;
        }

        public void RemoveMedicine(int elementId)
        {
            Medicine[] tempArray = new Medicine[DB.medicineData.Length - 1];
            int idx = 0;

            for (int i = 0; i < DB.medicineData.Length; i++)
            {
                if (DB.medicineData[i].Id != elementId)
                {
                    tempArray[idx] = DB.medicineData[i];
                    idx++;

                }

            }
            DB.medicineData = tempArray;

        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            int tempIdx = -1;

            for (int i = 0; i < DB.medicineData.Length; i++)
            {
                if (DB.medicineData[i].Id == id)
                {
                    tempIdx = i;
                    break;
                }
            }
            if (tempIdx >= 0)
            {
                DB.medicineData[tempIdx] = updatedMedicine;
            }
            else
            {
                Console.WriteLine($"Medicine data with ID--{id} doen't exsist.");
            }

        }
    }
}
