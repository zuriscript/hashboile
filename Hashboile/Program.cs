using Hashboile.Models;
using Hashboile.Utility.Execution;

var runner = HashBoileRunner.Create(inputFileTokenDelimitier: " ");

runner.Run(
    "a_an_example.in.txt", 
    "a_an_example.out.txt", 
    MetricDirective.General);

runner.RunWithSimulation(
    "b_better_start_small.in.txt", 
    "b_better_start_small.out.txt", 
    MetricDirective.General, 
    1);

runner.RunWithSimulation(
    "c_collaboration.in.txt",
    "c_collaboration.out.txt",
    MetricDirective.General,
    1);

runner.RunWithSimulation(
    "d_dense_schedule.in.txt",
    "d_dense_schedule.out.txt",
    MetricDirective.General,
    1);

runner.Run(
    "e_exceptional_skills.in.txt",
    "e_exceptional_skills.out.txt",
    MetricDirective.General);

runner.Run(
    "f_find_great_mentors.in.txt",
    "f_find_great_mentors.out.txt",
    MetricDirective.General);
