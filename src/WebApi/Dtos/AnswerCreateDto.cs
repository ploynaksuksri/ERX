namespace WebApi.Dtos
{
    public class AnswerCreateDto
    {
        public int PariticipantId { get; set; }
        public int QuestionId { get; set; }
        public string WrittenAnswer { get; set; }
        public int ChoiceId { get; set; }
    }
}