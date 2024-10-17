﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class QuizResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure only QuizId is an identity
        public int QuizId { get; set; }

        public int StudentId { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
    }

}