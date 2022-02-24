using Hashboile.Models;
using Hashboile.Utility.Execution;

var runner = HashBoileRunner.Create(inputFileTokenDelimitier: " ");

runner.Run(
    "a_an_example.in.txt", 
    "a_an_example.out.txt", 
    MetricDirective.General);

runner.RunWithSimulation(
    "b_better_start_small.in.in.txt", 
    "b_better_start_small.in.out.txt", 
    MetricDirective.General, 
    1);

runner.RunWithSimulation(
    "c_collaboration.in.in.txt",
    "c_collaboration.in.out.txt",
    MetricDirective.General,
    4);

runner.RunWithSimulation(
    "d_dense_schedule.in.in.txt",
    "d_dense_schedule.in.out.txt",
    MetricDirective.General,
    20);

runner.Run(
    "e_exceptional_skills.in.in.txt",
    "e_exceptional_skills.in.out.txt",
    MetricDirective.General);

runner.Run(
    "f_find_great_mentors.in.in.in.txt",
    "f_find_great_mentors.in.in.out.txt",
    MetricDirective.General);
