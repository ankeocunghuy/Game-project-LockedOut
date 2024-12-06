# Project 2 Report

## Table of Contents

- [Evaluation Plan](#evaluation-plan)
- [Evaluation Report](#evaluation-report)
- [Shaders and Special Effects](#shaders-and-special-effects)
- [Additional Challenges](#additional-challenges)
- [What We Would Do Differently](#what-we-would-do-differently)
- [Summary of Contributions](#summary-of-contributions)
- [References and External Resources](#references-and-external-resources)

## Evaluation Plan

### _Evaluation Techniques_
__Query:__ For the querying strategy, we will be sending a form to participants to gain feedback on our logic server design. Since the server is designed as a series of questions/logic puzzles, it will be easy to design a form that will simulate this. We would like to learn how well people perform on the puzzles, with a success rate around 70% our target, as well as if they find them enjoyable. An example of a question that might be on the form: 

<p align="center">
  <img src="https://github.com/user-attachments/assets/7ce8063c-4370-46e9-8a2b-9c571853e6d2" alt="Example Question from Query Questionnaire" width="400"/>
  <br>
  <i> Fig 1: Example Question from Query Questionnaire </i>
</p>



__Observational:__ For the observational strategy, we will organize calls with participants in which they will play the game through in its entirety. At the end of each server and the end of the game, they will give their feedback. We will be focusing on not only ensuring the game is fun to play, but also that it holds to the eerie world theme and that they pick up on our intended messaging. This will also be a check of the gameplay elements, that the movement feels natural, there are no bugs, etc.

### _Participants_
As mentioned in the GDD, the intended audience would be college students and recent graduates, so they will be the main targets for the evaluation. In both techniques, we will ask preliminary questions about gaming experience, college year, and whether or not they are Computer Science (CS) students. These can be seen in the form below. Since we are all CS students, and this is designed to mainly replicate the CS job application process it is important to gauge their opinions in particular. However, we are not restricting it to solely their opinions as this game is targeted towards all majors.

To find participants for both techniques, we will be asking our friends who tend to be either college students, CS Majors, or potentially both. To ensure variety, and ensure that we aren't overwhelmed with the amount of data, we  will be selecting 3-4 participants for the observational section. To 

To find participants we are just going to be asking our friends, as we are all college students. To ensure variety, and a reasonable amount of data and time committment, we will all be selecting 3 or 4 participants for the observational technique. To minimize biases, each of us will interview participants chosen by others in the group. For the querying technique, considering that the data would be mainly quantitative, having more data would be beneficial as aiming for that 70% success rate is one of our key focuses with this section. 

### _Data Collection_
We will use Google Forms for the querrying survey and Google Sheets for the observational strategy. Links to both of these are included, as well as a table outlining the data we are collecting for each technique. 

[Google Form](https://docs.google.com/forms/d/e/1FAIpQLScu_eFRrr8yC1Nd4fGQ8Er392qWsdTscH4EpMD0--pEW5y5Kw/viewform?usp=sharing) - Querying Evaluation

[Google Sheet Template](https://docs.google.com/spreadsheets/d/1oZoSPhRUxXmHhK2D7Gv0lHsf8hB8nZKM5L9P9-c0Yu4/edit?usp=sharing) - Observational Evaluation

|__Demographic Questions__|Responses|__Query Questions__|Responses|
|:---:|:---:|:---:|:---:|
|Are you in college?|Yes, Graduating This Year, Already Graduated|How long did those questions take to complete?|<1 minute, 1-2 minutes, 2-3 minutes, >3 minutes|
|Are/were you a computer science major?|Yes, No|How difficult were the puzzles?|Very Easy, Easy, Not Bad, Difficult, Very Difficult|
|Have you struggled with job/internship applications?|Not At All, Some,  A Lot|How did you enjoy the logic puzzles?|Not Fun, Alright, Kinda Fun, Very Fun|
|What is your experience with video gaming?|None, Very Little, Some, A Lot|If CS major, did they replicate experiences you've had in the interview process|N/A, No, Somewhat, Yes|

__Observational Questions__
_Asked at completion of servers and games, should be very short answers_
+ Did you find that element/the game enjoyable?
+ Was there any issues you had?
+ Does the game feel eerie?
+ Any suggestions or comments?

_Asked after completion of game, longer answers_
+ What did you feel the message of the game was?
+ Is this something you could see yourself playing?
+ Did you find the art styles to be consistent, and what did you think of the art?

In addition to these questions, we will also be recording how long it takes them to complete the game and take notes throughout about what they struggled with, found easy, or any comments they may make while playing.

### _Data Analysis_
Joel will lead on the data analysis, organizing the results into a more understandable format, such as tables and graphs. For the query technique, the results will be mostly relevant for Thane, as he is designing the logic puzzle level. We want below a 75% correctness rate for the logic puzzles, but above 60%.
However, for each we will be having group meetings to discuss the results and plans moving forward. The changes we make will be mostly based on the qualitative data we receive, using suggestions and feedback to update the game according to users responses. 

### _Timeline_
We would like to send out the survey as early as possible, so the first round will be going out right after this submission. Depending on the results, a second round of surveys could be done during Week 11. We want the game to be very finalized before running the observational evaluations, so that will take place during the end of week 11, giving us two weeks to evaluate the data and make changes. This means we want to have our game fully implemented by the end of week 11.

### _Responsibilities_
We had a team meeting during which we discussed all of this, and the majority of this plan was written by Nathan. The Google Form and interview template will also be made by him. Thane is responsible for designing the questions for the logic puzzles in his level, which means completing the form. Joel will take the lead on organized and analyzing the data, but everyone will be involved. Each of us will conduct 3-4 interviews of the participants others find, ensuring we all get an experience of the evaluation technique.

### _Goals_
Our goals in this evaluation is to first get a gauge on how people feel about the logic server. This is the server with the least gameplay, but is important to give our game the feel of a job application. In the survey we are sending out, we want to learn how people feel about the puzzles we will be presenting to them. It will tell us how enjoyable they are, how difficult, and how much it feels similar to the real job application process. This will be key in ensuring our game has the consistent theme of a job application while also still being engaging and fun to play. Furthermore, we want to find the perfect balance of an engaging and interactive experience and a real-life skills assessment. 

The secondary evaluation will give us a better feel on the overall game. We want to make sure our game is following the eerie world theme, which we will learn about at the end of each server and at the end of the game. We have some specific scenes and characters that are specifically eerie, and would like feedback on them. We also want to ensure that our game runs well and coherently from start to finish. Finally, since our game is designed to be a commentary on the job application process, outlining the simplistic and sometimes stupid things one must do to have a resume that will pass an AI's inspection, we want to check that our messaging comes through clearly. To ensure that our participants do not have inherent biases, we will not give them background information and refrain from providing any feedback while they play, sticking closely to our designated questions.

### _Interview Strategies_
As mentioned above, we do not want to influence our participants' responses, so we will be taking several steps to ensure this. Firstly, we will each interview someone else's participants. Secondly, we won't give any information about the game before, during, or after they play.
Lastly we will stick closely to only asking the prewritten questions during the interview and not answer any questions they may have, nor will we give help if they get stuck in the game. We want to simulate the experience of playing the game to the best of our ability, and we believe that these steps will ensure that this is done. 

## Evaluation Report

### Data

#### Query Technique Evaluation Report 

For the query evaluation section of the report, 11 participants took our survey, resulting in more data to help with the analysis. As mentioned in the evaluation plan with regards to the questions, the expected success rate was between 60% and 75%. 

Our survey results yielded a score of 3.09 / 5 which would represent a 61.8% average score This score  just barely passes the minimum value that we were looking for. The most common score that participants got was 4/5 with 4/11 participants achieving this score. With regards to the lower and upper extremes, 1 participant scored 1/5 while another scored 5/5. A better visualization of the results can be found below: 

<p align="center">
  <img src="https://github.com/feit-comp30019/2024s2-project-2-tentaculiferous-trinity/blob/main/GDD%20Content/Player%20Scores.png" alt="Survey Results" width="400"/>
  <br>
  <i>Fig. 2: Distribution of survey results. </i>
</p>

##### _Raw Scores_

With Regards to individual questions and the scores, they are summarised in the table below: 

|Question | Raw Score | Percentage Values |
|-----------|----------|----------|
| 1 | 10/11 | 90.91% | 
| 2 | 5/11 | 45.45% |
| 3 | 4/11 | 36.36% | 
| 4 | 6/11 | 54.55% |
| 5 | 9/11 | 81.82% |

The questions that the participants struggled with most was question 2 and question 3 with only 5 and 4 participants getting the right answer respectively. This coupled with the fact that 50% of participants took more than 3 minutes (Figure 3). This would mean that server 1 alone would take too long to complete which would disrupt the timing of the entire game. 

<p align="center">
  <img src="https://github.com/feit-comp30019/2024s2-project-2-tentaculiferous-trinity/blob/main/GDD%20Content/Distribution%20of%20amount%20of%20time%20taken.png" alt="Time Duration Results" width="400"/>
  <br>
  <i>Fig. 3: Length taken to Complete Questions </i>
</p>

Our survey population was diverse, providing a balanced perspective on the general population's views for several of the questions. There was a nearly even split between college graduates (45.5%) and current college students (54.6%). Interestingly, only 3 of the 11 participants had a computer science background, with the others coming from various fields. While this diversity offered valuable insights, it limited the responses for our final question:

'If you are a CS major, were these questions similar to those you've encountered in online assessments for internship applications?'

As expected, the most common response was 'N/A,' indicating that while the questions effectively gauged success rates, they may not be as useful for assessing how closely they align with real-world assessments.

With regards to the fun, and the enjoyment people recieved from the puzles, there was a mixed distribution of final results. 3/11 participants rated the puzzles as being 1/5 in terms of enjoyment. In comparision, 6/11 rated a 3 or higher with their enjoyment. The range in values is interesting as by tracking -> 

#### Observational Technique Evaluation Report

Our original plan was to interview 4 people each, but as time progressed this became unrealistic due to the contraints of being a college student during finals. We also were held back from conducting interviews for longer than expected because unforeseen troubles in development slowed our pace. We were still able to conduct 7 interviews, with the data being stored in this [EvaluationData.md](Images/EvaluationData.md). Since this data is largely qualitative, our physical data analysis was limited, we instead focused on discussing the results amongst ourselves as we conducted interviews. 

Although we did not manage to interview 16 people, we were still able to get a large variety of video game experience levels. The way we selected the participants was primarily through friends. Also, since interviews took place at several points along development, some of the elements were different between interviews, and a common theme was that the lava was not working. During the interviews, a bug with script naming removed its functionality for several days. Also, some interviews were conducted while certain levels were entirely missing, or conducted in just one level, so some only have data specific for certain levels.

### _Modifications to the Game_ 

#### _Querying Technique Results_ 
In order to remedy this, question 3 has been taken out of the logic puzzle section. This is to reduce the overall playtime as well ensure that participants would not be frustrated. By removing this question, and looking at the average score, it comes out to 2.72/4 which represents a 68% success rate. This success rate nestles comfortably between our 60% and 75% range. 

A slight variation is that with the survey, partipants wouldn't know their final results. However in the game, the players would instantly know; Picking the right answer they'd move forward while incorrectly picking a question would send the player back to the beginning. This has to be taken into consideration with designing the level.

Therefore, the location of the questions and ensuring that there is some spread throughout the level is important as well. As a result, question placement is varied; The questions alternate between easy, hard, easy, hard. Reducing the number of questions helps with the irrational player; The individual would just run and try every question as opposed to thinking about it. 

#### _Observational Technique Results_ 

Seven interviews were conducted in total, with Nathan doing three, Thane two, and Huy  one. As mentioned, interviewees were not interviewed by their friends to reduce the potential for bias and helping throughout all the stages. Prior to starting the game, similiar to the querying technique, questions were asked to ask about the participants demographics such as whether they were in college as well as their previous gaming experience. Once that was concluded, participants were allowed to play the game. Interviewers had to just note anything interesting that participants did throughout the levels. For instance, both of Thane's participants immediately started to walk away from the stage at the very start of the game. This was interesting to note, as it almost seemed contradictory. When asked about it, one said that "they were looking to see something else if it was hidden or anything". 

Observation was interesting as participants discovered their own shortcuts to accelerate gameplay. When moving from part 1 to part 2 in Server 2, normally the player would move one character at a time to the next room. However, one participant thought to using player 1 to push player 2, making it easier for her to start section 2. While not explicitly told so, participants also voiced their discomfort with certain parts of the level. One participant struggled with the difference between switching and restarting the level as they would accidentally restart when they meant to swap cameras. However this was shortly rectified by the participant. 

The biggest thing we learned from the game was that it was too long. On average, the subjects took 15-25 minutes to complete the game. This is obviously well over the time limit we have in place for the game, so we decided to remove one question from server 1 (the hardest one), and cut out the first half of server 2. The decision to cut so much from Server 2 was because it was the longest level of the game, and the first half was designed as an intro to the mechanic of switching bodies, and thus was not as innovative as the second part. We also learned that it was possible to get softlocked in Server 2 through interviews, which led to the implementation of the reset button. These two changes counteracted each other (soft lock only happened in first part), but we decided to keep the reset button as an easter egg about the development of the game and challenges we faced.

The second most common piece of feedback was about the character movement. This is a component of the game that could definitely use more work, but due to time constraints we were unable to make substantial changes to it. When initially coding the project, the goal was for a 'dreamlike' feeling and for it to feel surreal and off-putting. While this ideas was great, in execution it often meant that players were slipping around the level, and unable to control their acceleration and movement to the best of their ability. This was extremely problematic in Server 3 as being a platformer would be challenging. Coupled with 'ice-skating'graphics as one interviewee put it made it extremely challenging to navigate. Those were the biggest changes that the participants mentioned in regards to gameplay. 

The second set of questions were also very important as we were able to gauge whether the themes and the explicit goal of the game was able to be identified. The team agreed that players shouldn't be briefed or given any sort of preamble for the story, instead waking up disoriented and confused at their graduation. This worked to some extent as players were able to gauge that the game had something to do with university and all the skills you need to pass. They got a little confused with whether it was the working life, as certain elements such as the 'demotivational' posters and the players in server 2 wearing the graduation robes tended to be confusing. 

<p align="center">
  <img src="https://github.com/user-attachments/assets/37d083c0-e964-4b48-a4ac-ec0626efa8ef" alt="Server1 Posters" width="400"/>
  <br>
  <i>Fig. 7: An example of a de-motivational poster scattered throughout server 1 </i>
</p>

We also received a lot of positive feedback on the music, sound effects, art style, and lighting. The feelings on how eerie the game was were mixed, but everyone agreed the music and lighting added to it. Another common theme throughout those we interviews, especially with little gaming experience, was that the instructions were unclear. This was intentional, though, as we want the player to be confused and feel lost as to what they are supposed to do, much like we have felt while trying to apply for internships and jobs. After the interviews, we also added an ending scene that explains the purpose of the game sort of, so that will help people understand what the message is more clearly.

Our game is designed to be played in not a rush, with a lot of small details that may go unnoticed until you examine them. In the server room, the clerk represents an AI resume screening process. Server 3 is a commentary on the process of coding, where one small bug can force you to restart your entire project. Server 1 has a bunch of sarcastic inspirational posters custom designed by Thane, as well as a facetious instruction page, and letter of denial. These are meant to be slowly enjoyed and read, so it's a shame that we are forced to rush through the game.

## Shaders and Special Effects

### Shader 1
The first shader we used was implemented in a variety of different objects, as it was highly customisable, but most notably it was used on the clerk in the main server room. The basic idea behind this shader was to simulate a screen with matrix-esque green lines moving along its surface. To get this effect, it required moving the UVs of the texture along the object at a continuous rate so that the image we used as a texture would appear to move. To get the effect of a screen's surface reflectivity, I used the Phong shader we learned in discussion to allow for large amounts of customization to the reflectiveness, highlights, and lowlights of the object. Finally, I also added a glow color and intesity so that the head of the clerk would be illuminated even from across the room. The clerk head used a green background with green lines and a green glow. The cloak was supposed to appear as a screen like fabric, so the green highlights along the surface and softer green glow added that effect, but the overall darkness of the robe kept it looking mysterious.
The clerk represents the AI that are used in modern job application processes to thin out the application pool, so I wanted the materials used for it to be able to show this to the player if they looked. This gives a hint towards the message of the game while also giving an eerie, mysterious feel to the centerpiece of our main level.
This shader was also used in a variety of other materials, notably: the ground under the grass in the grad scene, the substance behind each door, and the sky in the logic puzzle server.

**Pictures**
<p float="left">
  <img src="GDD Content/ClerkShader.gif" width="500" />
  <img src="GDD Content/ClerkHeadShaderOptions.png" width="200" /> 
</p>


### Shader 2
The second shader was used for the lava. To make the lava feel real, I wanted to have it appear to be moving and choppy as it rapidly fills up the room. To do this, I used a height map from an online source and a lava jpeg as the texture. For each vertex, I got the color of the height map calculated the height based on this. Then I moved the UVs along the object as I did in shader 1. To make the ripples appear fluid, I used a similar technique but with the coordinates of the height map, and moved them in a different direction. This gives the lava the feel that it is a fluid and is washing over the tiles that it consumes. I also added an orange glow to the lava to make it appear like real lava. A challenge with this was using a Unity plane, since it only has 4 vertices, but I was able to work around this by adding a custom plane from Blender with many vertices.

**Pictures**

<p float="left">
  <img src="GDD Content/LavaShader.gif" width="500" />
  <img src="GDD Content/LavaShaderOptions.png" width="225" /> 
</p>

### Particle System
The particle system was used in the transitions between levels with the goal to make it appear as if the player was being transported through wires of the server rack into the next challenge. This was done by creating a scene that held a long black pipe, a camera, and the particle system. The particle system was set as a circle in front of the player, and triggered upon entering the level. It shoots large numbers of particles with a long tail streaming behind that transition from white to blue, which are colors that usually signify technology. Then I made the particles spin around the z-axis as they went, as wires are twisted around each other within wires.

**Pictures**
<p float="left">
  <img src="GDD Content/ParticleSystem.gif" width="600" />
  <img src="GDD Content/ParticleSystem1.png" width="150" /> 
  <img src="GDD Content/ParticleSystem2.png" width="200" /> 
</p>

## Additional Challenges

### .gitignore

During the second commit of project two, a group member somehow pushed a modified .gitignore file to the main repo, meaning that every file from the Library folder was pushed to our repo. Since this happened so early on, we did not realise that something was incorrect, and throughout the entire project had pushes containing hundreds of library files. This was because every time someone from a different operating system pulled, their computer replaced every '\' with a '/' and vice versa. This also caused several problems with the github submissions being too large. During the final week, we finally discovered this problem and fixed it, but not without some scares caused from using Github Desktop while Unity was open.

### The Lava and Gradescope WebGL Build

In Unity, there is a script to reset you to the start when you hit the level. It works fine in Unity, but in the WebGL build it does not. To counteract the tedium this places on the character to walk back over lava to the start, we decided to have the lava slowly push upwards and actually help a struggling player boost to the end of the level. This can still work with our game, since it subverts player expectations of what lava should do in a game, and represents how something that can be harmful and destructive can still help you, much like AI helps programers every day.

The problem with the Gradescope build, we are not sure about. The game builds and runs correctly on all our machines in WebGL, but when we submit it to Gradescope and try to play on the website of games, the main server room fails to load in. We think this may have to do something with the Hammer -> Blender -> Unity pipeline, but we do not know what is causing it. We sent an email to Alex with a video showing the full playthough of the game to show that it was done on time.

### General Github/Unity Troubles

There were many instances where our pushes and pulls got inexplainably freaked up, but most notably, Joel pushed a change to add his Server 2 design, and somehow the entire past two weeks of work got deleted. Luckily, Thane noticed this and told me (Nathan) to make a separate branch before pulling, and we were able to fix it. But it was stressful.

### Group Responsiveness

Group projects are always hard to manage, and this was no exception. As college students, we are all very busy, and there was a few times when people would go silent for several days at a time, which made staying on track very difficult. Trying to wrangle these group members (Nathan speaking here) has been a bit of a struggle admittedly, but I love the guys.

## What We Would Do Differently

If we could go back and tell our past selves some tips, they would probably go something like this
1. Dream smaller, you'll never finish all those big ideas in such little time
2. Never EVER pull from Github while you have Unity open
3. Get your assignments submitted the night before they're due, it'll save you at least 3 hairs
4. Set up weekly in person meetings, and send updates into the discord a few time each week
5. Spread the work amongst the group more evenly, and have better assignment strategies
6. Respond in the Discord when you get @ed pls :'(

### A Note From Nathan
In all, this was a very fun project, and I quite liked my group. I hate how Github and Unity work together, but I think that was kinda our fault. I am very proud of the game we managed to build this semester, even if it didn't quite live up to our goals. I really enjoyed putting work in and watching it slowly come into being. If I had seen this game a few months ago, I never would've believed I helped make it. I think our game is beautiful, and I hope you enjoy it too. And maybe if you're a bit of a speedrunner, you'll have the time to appreciate all the work we put into those small details. Thanks for taking the time to grade our report mystery TA. I'll be back in the US soon, but I'll be bringing a piece of what this class taught me to create back with me.

## Thane Note's 
This subject was incredible. There's so much to learn, and we just get to dip our toes into the proverbial sea of 3D modelling. The ability and creativity to make whatever you want and only being limited by your imagination is something no other subject really gives you the ability to do so. I really appreciate how much we get to learn in a short time span. It's incredible. Please enjoy. 

## Summary of Contributions

|Topic | Nathan | Thane | Joel | Huy |
|-----------|----------|----------|----------|----------|
| **Reports** | Wrote evaluation plan including Google Form and interview questions, evaluation assessment, and shaders and special effects section of report  | Wrote almost entirety of GDD, Created and managed the Project Management/Kanban Board - Trello, Designed visaul assets to be used for the questionaire, wrote Evaluation report | Did data analysis of evaluation results, created graphics and data presentation of survey | Brainstorming |
| **Video Game** | Wrote both shaders, designed particle effect, grad scene and loading screen, movement script | Server 1 including questions, scene transitions, visual assets used throughout the game as well as Server 4 | Server 2 game, multi-player script, secondary movement script, all server exit door script to track game progress | Server 3 |
| **3D Modeling** | Used Blender to design clerk, all grad student models, door model, Locked Out logo | Layout of Server 1, Gates, Clerk assets - Stamp | Created server room 2 and main server room models via the following workflow pipeline: hammer source 2 engine -> blender (create textures) -> export blend file into unity and apply textures. |  |

## References and External Resources

### Links to external sources used

[Fabric Material](https://assetstore.unity.com/packages/2d/textures-materials/fabric/yughues-free-fabric-materials-13002)
[Grass Model](https://www.turbosquid.com/3d-models/3d-grass-plant-model-1407850)
[Grad Cap](https://www.turbosquid.com/3d-models/graduation-hat-model-1242220)
[Wooden Chair](https://www.turbosquid.com/3d-models/3d-model-worn-wooden-chair-1839856)
[Lava Height Map](https://4.bp.blogspot.com/-QjTpkXIFvPQ/V19e6tGjdaI/AAAAAAAAAUs/cvVgKLZf4eU1KKV2RpdXi1Df48PAiT8uQCLcB/s320/water_new_height.png)
[Hammer Source 2 Editor](https://developer.valvesoftware.com/wiki/Source_2)
[Hammer->Blender FBX Pipeline](https://www.blender.org)
[Unity Documentation](https://docs.unity.com)
[Lava PNG](https://www.google.com/search?sca_esv=c649270f8124ba4f&sxsrf=ADLYWILWzgvzzuZbRkUS1A6U7Yg9kC6wYQ:1729574123722&q=lava+png+tiling&udm=2&fbs=AEQNm0BcOTtrxLAuu_QwMeob8rlZbzgoNyvm-EGzMCdSVm7atMhtCrLJ0m6k84h6T6DB016P3Aln0I7mw8h0z4ILkQ8VYnQc9vclr77uiyRGhg5wnpHFxtK5zp63LgMTwbavR_XZSr4d-4Ju5bMxthyZsbWsxZervavD_7JmnBcmFR7fGVLsCmOtHbqL3ETKc7wlaLG_6FFutEykGj0evlNkSXKGcIVBcA&sa=X&ved=2ahUKEwimhIfanaGJAxV-8DQHHbt5CVYQtKgLegQIDxAB&biw=1512&bih=749&dpr=2#vhid=UXGO4OfGEgkrXM&vssid=mosaic)
[Arch](https://www.youtube.com/watch?v=lFIBZ5lPLes&t=371s)
[Blender-WallFactory](https://www.youtube.com/watch?v=y45J5pNrbaY)

Posters - Demotivational
[Forks](https://www.reddit.com/r/DemotivationalPosters/comments/8brfa2/just_because_youre_different_doesnt_mean_youre/)
[Innovation](https://despair.com/products/innovation)
[Uniqueness](https://www.pinterest.com/pin/169870217187460867/)
[Job Interview](https://es.pinterest.com/pin/545217098646138167/)
[Motivation](https://training.artenprise.eu/en/training-area/module-4-self-motivation)
[Dedication](https://www.reddit.com/r/Demotivational/comments/5mkm2j/dedication/)
[Trust](https://www.reddit.com/r/Demotivational/comments/6q0eku/trust/)
[Death](https://preview.redd.it/hnpwrcwvdexa1.jpg?width=640&crop=smart&auto=webp&s=00901b209fe0c24ab716928c204f2248ffbe2c95 )

