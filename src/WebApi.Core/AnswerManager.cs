using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Helper;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Core
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IParticipantRepository _participantRepository;

        public AnswerManager(IAnswerRepository answerRepository,
            IParticipantRepository participantRepository)
        {
            _answerRepository = answerRepository;
            _participantRepository = participantRepository;
        }

        public async Task<Answer> Add(Answer answer)
        {
            if (answer.Participant == null)
            {
                answer.Participant = await CreateParticipant(new Participant() { LastQuestion = answer.Question });
            }
            else
            {
                answer.Participant = await GetParticipant(answer.Participant.Id);
                answer.Participant.LastQuestion = answer.Question;
            }

            var result = await _answerRepository.Add(answer, true);
            await _participantRepository.Update(answer.Participant);
            return result;
        }

        public async Task<string> GetCsvAsync()
        {
            var answers = await _answerRepository.GetAll();
            var csv = AnswerHelper.GenerateCsv(answers);
            return csv;
        }

        #region private methods

        private async Task<Participant> CreateParticipant(Participant participant)
        {
            var result = await _participantRepository.Add(participant, true);
            return result;
        }

        private async Task<Participant> GetParticipant(int participantId)
        {
            var result = await _participantRepository.Get(participantId);
            if (result == null)
                throw new Exception("This participant doesn't exist.");

            return result;
        }

        #endregion private methods
    }
}