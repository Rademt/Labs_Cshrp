using System;

namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("_-_-_-_-СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ_-_-_-_-\n");

            Hospital hospital = new Hospital();

            Doctor d1 = new Doctor(1, "Тараканов Родіон", "Хірург");
            Doctor d2 = new Doctor(2, "Кобилиньска Ангеліна", "Педіатр");
            Doctor d3 = new Doctor(3, "Кошкіна Лілія", "Психіатр");

            hospital.AddDoctor(d1);
            hospital.AddDoctor(d2);
            hospital.AddDoctor(d3);

            Patient p1 = new Patient(1, "Демченко Євгеній", 30);
            Patient p2 = new Patient(2, "Черніков Ярослав", 18);
            Patient p3 = new Patient(3, "Віктор Дудка", 17);

            hospital.RegisterPatient(p1);
            hospital.RegisterPatient(p2);
            hospital.RegisterPatient(p3);

            HospitalRoom r1 = new HospitalRoom(10, 2);
            HospitalRoom r2 = new HospitalRoom(11, 2);
            HospitalRoom r3 = new HospitalRoom(12, 1);

            hospital.CreateRoom(r1);
            hospital.CreateRoom(r2);
            hospital.CreateRoom(r3);

            hospital.HospitalizePatient(1, 10);
            hospital.HospitalizePatient(2, 11);
            hospital.HospitalizePatient(3, 11);
            hospital.HospitalizePatient(4, 12);

            MedicalRecord m1 = new MedicalRecord(p1, d1, DateTime.Now, "Ампутування ноги");
            MedicalRecord m2 = new MedicalRecord(p2, d2, DateTime.Now, "Застуда");
            MedicalRecord m3 = new MedicalRecord(p3, d3, DateTime.Now, "Проблеми с головою");

            hospital.AddMedicalRecord(m1);
            hospital.AddMedicalRecord(m2);
            hospital.AddMedicalRecord(m3);

            Console.WriteLine("\n_-_-_-_-ІСТОРІЯ ПАЦІЄНТА_-_-_-_-");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"Лікар: {record.Doctor.Name}");
                Console.WriteLine($"Опис: {record.Description}\n");
            }

            Console.WriteLine(hospital.GetStatistics());
        }
    }
}
