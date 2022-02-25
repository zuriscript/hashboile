# Hashboile

This Repo is intended as skeleton Codebase for Google Hashcode coding competition or other similar competition formats.

- `Program.cs`: About what and how to run
- `Contracts/`: Against which interface you should implement
   - `IInputParser`: Declare how to parse the input
   - `IOutputSerialize`: Declare how to write the result to file
   - `ISolver`: Implement you Soultion, taking an `Input` and returning an `Output`
   - `ISimulator`: Optionally, you can score your solutions to take the best one (if using nondeterminism)
- `Implementaions/`: Here you're code, based on `Contracts`, should go
- `Models/`: Your Models
   - `Input`:  Input schema based on Competition description
   - `Output`: Ouput schema based on Competition description
   - `MetricDeterminism`: You can place a hint per file (for example if you know a priori that for that certain file the number of streets or something has some special influence etc.). You can use this enumeration in the solver as well as in the scorer.
- `Utility/`: Helper for Program, you probably won't have to change a thing there



## Algorithm 1
Parameter
- ScoreAwardedForCompletion high
- NumberOfDaysToComplete low
- CompleteBestBeforeDay < today + NumberOfDaysToComplete
- feasible ? contributor with skill available?
- complex -> amount of skills, level of skills
- put people on role with same level as skill so they can upskill

- mentorship


- timeline loop
- based on projects?





## Learnings: Please 2023
- Nicht den Simulator programmieren, sondern die Naive Lösung verbessern:
  - Simulator/Optimale Lösung dauert zu lange
  - Heuristiken einbauen
  - Score anhand der Parameter für jedes Projekt einbauen -> danach sortieren
  - Naive Lösung dauerte schon über 80 Sekunden für F -> nicht mehr komplexität einbauen
  - Naive Lösung ist immer schon gut genug!

- In den Submissions den Text lesen, was nicht gut war -> Parameter Gewichtung verbessern

- Pair Programming gut am Anfang

- Evt. gegen Schluss noch jede Person fokussiert auf ein anderes Szenario
- Distributionen einbauen -> welche Skills sind wertvoller als andere (haben weniger Leute) etc -> bei gewichtung einbauen