using NGK_GestContact.Api.Domain.Commands;
using NGK_GestContact.Api.Domain.Entities;
using NGK_GestContact.Api.Domain.Mappers;
using NGK_GestContact.Api.Domain.Queries;
using NGK_GestContact.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Results;
using Tools.Database;

namespace NGK_GestContact.Api.Domain.Services
{
    public class ContactService : IContactRepository
    {
        private readonly DbConnection _dbConnection;

        public ContactService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public async Task<ICqsResult> ExecuteAsync(CreateContactCommand command)
        {
            try
            {
                int rows = await _dbConnection.ExecuteNonQueryAsync("INSERT INTO Contact (Nom, Prenom, Email, Tel) VALUES (@Nom, @Prenom, @Email, @Tel);", false, command);

                if (rows != 1)
                {
                    return ICqsResult.Failure("Quelque chose s'est mal passé");
                }

                return ICqsResult.Success();
            }
            catch (Exception ex)
            {
                return ICqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(CreateContactCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("INSERT INTO Contact (Nom, Prenom, Email, Tel) VALUES (@Nom, @Prenom, @Email, @Tel);", false, command);

                if (rows != 1)
                {
                    return ICqsResult.Failure("Quelque chose s'est mal passé");
                }

                return ICqsResult.Success();
            }
            catch (Exception ex)
            {
                return ICqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<Contact> Execute(GetContactByIdQuery query)
        {
            try
            {
                Contact? contact = _dbConnection.ExecuteReader("SELECT Id, Nom, Prenom, Email, Tel FROM Contact WHERE Id = @Id", dr => dr.ToContact(), false, query).SingleOrDefault();

                if (contact is null)
                    return ICqsResult<Contact>.Failure("Contact not found!");

                return ICqsResult<Contact>.Success(contact);
            }
            catch (Exception ex)
            {
                return ICqsResult<Contact>.Failure(ex.Message);
            }
        }

        public async Task<ICqsResult<Contact>> ExecuteAsync(GetContactByIdQuery query)
        {
            try
            {
                Contact? contact = (await _dbConnection.ExecuteReaderAsync("SELECT Id, Nom, Prenom, Email, Tel FROM Contact WHERE Id = @Id", dr => dr.ToContact(), false, query)).SingleOrDefault();
                
                if(contact is null)
                    return ICqsResult<Contact>.Failure("Contact not found!");

                return ICqsResult<Contact>.Success(contact);
            }
            catch (Exception ex)
            {
                return ICqsResult<Contact>.Failure(ex.Message);
            }
        }
    }
}
