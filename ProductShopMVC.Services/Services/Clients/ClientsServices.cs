using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Clients;
using ProductShopMVC.Services.Repositories.Clients;
using ProductShopMVC.Tools.Errors;
using ProductShopMVC.Tools.Generate;
using ProductShopMVC.Tools.Check;

namespace ProductShopMVC.Services.Services.Clients
{
    public class ClientsServices
    {
        public List<Client> GetAllClients(out DefaultError outError)
        {
            outError = new DefaultError();
            List<Client> result = ClientsRepository.GetAllClients();

            if (result == null || !result.Any())
            {
                outError.ErrorMessage = "Список клиентов пуст!";
                return new List<Client>();
            }
            return result;
        }
        public Client GetClientById(string id)
        {
            return ClientsRepository.GetClientById(id);
        }

        public void AddClient(AddEditClient clientFromView, out DefaultError outError)
        {
            if (CheckClient(clientFromView, out outError))
            {
                ClientsRepository.AddClient(SetClientData(clientFromView));
            }
        }
        public void EditClient(AddEditClient clientFromView, out DefaultError outError)
        {
            if (CheckClient(clientFromView, out outError))
            {
                ClientsRepository.EditClient(SetClientData(clientFromView));
            }
        }

        private bool CheckClient(AddEditClient clientFromView, out DefaultError outError)
        {
            outError = new DefaultError();
            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckClientNull(clientFromView)))
            {
                return false;
            }
            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckClientData(clientFromView)))
            {
                return false;
            }
            return true;
        }

        private Client SetClientData(AddEditClient clientFromView)
        {
            Client newClient = new Client();
            newClient.ClientId = String.IsNullOrEmpty(clientFromView.ClientId) ? GeneratorId.GenerateId() : clientFromView.ClientId;
            newClient.ClientLastName = clientFromView.ClientLastName;
            newClient.ClientFirstName = clientFromView.ClientFirstName;
            newClient.ClientMiddleName = clientFromView.ClientMiddleName;
            newClient.ClientBirthday = DateTime.ParseExact(clientFromView.ClientBirthdayString, "yyyy-mm-dd", null);
            newClient.ClientPhoneNumber = clientFromView.ClientPhoneNumber;
            newClient.ClientEmail = clientFromView.ClientEmail;
            return newClient;
        }
        private string CheckClientNull(AddEditClient clientFromView)
        {
            return clientFromView == null ? "Ошибка данных! Пустая форма клиента." : null;
        }
        private string CheckClientData(AddEditClient clientFromView)
        {
            DateTime checkDate = DateTime.ParseExact(clientFromView.ClientBirthdayString, "yyyy-mm-dd", null);

            if (String.IsNullOrEmpty(clientFromView.ClientLastName))
            {
                return "Ошибка ввода ФИО! Пустое значение Фамилии. (server)";
            }
            if (String.IsNullOrEmpty(clientFromView.ClientFirstName))
            {
                return "Ошибка ввода ФИО! Пустое значение Имени. (server)";
            }
            if (String.IsNullOrEmpty(clientFromView.ClientMiddleName))
            {
                return "Ошибка ввода ФИО! Пустое значение Отчества. (server)";
            }
            if (checkDate.CompareTo(DateTime.Today) > 0)
            {
                return "Ошибка ввода Даты рождения! Выбрана неправильная дата. (Позднее текущего дня.)(server)";
            }
            if (checkDate.CompareTo(new DateTime(1900, 01, 01)) < 0)
            {
                return "Ошибка ввода Даты рождения! Выбрана неправильная дата.(server)";
            }
            if (!CheckData.checkPhoneNumber(clientFromView.ClientPhoneNumber))
            {
                return "Ошибка ввода Номера телефона! Введите номер согласно форме +7(***)***-**-**";
            }
            if (!CheckData.checkEmail(clientFromView.ClientEmail))
            {
                return "Ошибка ввода E-mail. Неправильная форма записи (server)";
            }
            if (!checkUniqEmail(clientFromView))
            {
                return "Ошибка ввода E-mail. Клиент с таким E-mail адресом уже существет!";
            }
            return null;
        }

        private bool checkUniqEmail(AddEditClient clientFromView)
        {
            if (!String.IsNullOrEmpty(clientFromView.ClientId))
            {
                if (String.Compare(clientFromView.ClientEmail, ClientsRepository.GetClientById(clientFromView.ClientId).ClientEmail) == 0)
                {
                    return true;
                }
            }
            if (ClientsRepository.GetClientByEmail(clientFromView.ClientEmail) == null)
            {
                return true;
            }
            return false;
        }
    }
}
