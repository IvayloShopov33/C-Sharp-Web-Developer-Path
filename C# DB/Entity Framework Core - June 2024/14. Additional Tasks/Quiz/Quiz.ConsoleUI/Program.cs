using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Quiz.Data;
using Quiz.Services;
using Quiz.Services.Contracts;

namespace Quiz.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();

                var quizService = serviceProvider.GetService<IQuizService>();
                quizService.Add("C# DB");

                var questionService = serviceProvider.GetService<IQuestionService>();
                questionService.Add("What is Entity Framework Core?", 1);
                questionService.Add("What is ADO.Net?", 1);

                var answerService = serviceProvider.GetService<IAnswerService>();
                answerService.Add("It's an ORM", true, 3, 1);
                answerService.Add("It's a MicroORM", false, 0, 1);
                answerService.Add("It's not related to the topic of Entity Framework Core", false, 0, 3);

                var jsonInputService = serviceProvider.GetService<IJsonInputService>();
                jsonInputService.Import("EF-Core-Quiz.json");

                var db = serviceProvider.GetService<ApplicationDbContext>();

                foreach (var user in db.Users)
                {
                    Console.WriteLine(user.UserName);
                }

                var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
                userAnswerService.AddUserAnswer(db.Users.FirstOrDefault()!.Id, 1, 2);

                var quiz = quizService.GetQuizById(1);

                Console.WriteLine(quiz.Title);

                foreach (var question in quiz.Questions)
                {
                    Console.WriteLine(question.Title);

                    foreach (var answer in question.Answers)
                    {
                        Console.WriteLine($"{answer.Title} -> {answer.Points}");
                    }
                }

                Console.WriteLine(userAnswerService.GetUserResult(db.Users.FirstOrDefault()!.Id, 1));
            }
            catch (Exception)
            {
                Console.WriteLine("Error.");
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
            services.AddTransient<IJsonInputService, JsonInputService>();
        }
    }
}