using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class WriterService : IWriterService
    {

        private readonly IWriterRepository _writerRepository;

        public WriterService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public List<WriterResponse> GetAll()
        {
            List<WriterResponse> writerResponses = new List<WriterResponse>();
            foreach (var writer in _writerRepository.GetAll())
            {
                writerResponses.Add(new WriterResponse(writer));
            }
            return writerResponses;
        }

        public WriterResponse GetById(int id)
        {
            Writer foundWriter = _writerRepository.GetById(id);
            if (foundWriter != null)
                return new WriterResponse(foundWriter);

            return null;
        }

        public WriterResponse Create(WriterRequest writerRequest)
        {
            Models.File profil = null;
            if (writerRequest.Profil.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    writerRequest.Profil.CopyTo(stream);
                    var bytes = stream.ToArray();

                    profil = new Models.File()
                    {
                        Name = writerRequest.Profil.FileName,
                        Type = writerRequest.Profil.ContentType,
                        Content = bytes
                    };
                }
            }

            Writer addedWriter = new Writer()
            {
                FirstName = writerRequest.FirstName,
                LastName = writerRequest.LastName,
                Profil = profil,
                Gender = writerRequest.Gender,
                Nationality = writerRequest.Nationality,
                Biography = writerRequest.Biography
            };

            Writer returnedWriter = _writerRepository.Create(addedWriter);
            return new WriterResponse(returnedWriter);
        }

        public WriterResponse Update(int id, WriterRequest writerRequest)
        {
            Models.File profil = null;

            if(writerRequest.Profil != null)
            {
                if (writerRequest.Profil.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        writerRequest.Profil.CopyTo(stream);
                        var bytes = stream.ToArray();

                        profil = new Models.File()
                        {
                            Name = writerRequest.Profil.FileName,
                            Type = writerRequest.Profil.ContentType,
                            Content = bytes
                        };
                    }
                }
            }

            Writer updatedWriter = _writerRepository.GetById(id);
            updatedWriter.FirstName = writerRequest.FirstName;
            updatedWriter.LastName = writerRequest.LastName;
            updatedWriter.Gender = writerRequest.Gender;
            updatedWriter.Nationality = writerRequest.Nationality;
            updatedWriter.Biography = writerRequest.Biography;

            if(writerRequest.Profil != null)
            {
                updatedWriter.Profil = profil;
            }

            Writer returnedWriter = _writerRepository.Update(updatedWriter);
            return new WriterResponse(returnedWriter);
        }

        public bool RemoveById(int id)
        {
            return _writerRepository.RemoveById(id);
        }

    }
}
