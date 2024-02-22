# 🥷🏽 React TrackTech project

A anomaly display project with React and Javascript. Teammembers:

- [Jarne Dirken](https://github.com/jarnedirken)
- [Dennis Raaijmakers](https://github.com/dennis-r)
- [Moussa Marmouch](https://github.com/moussamarmouch)
- [Jonas Baelus](https://github.com/JonasBaelus)
- [Sam Van Den Bogerd](https://github.com/samvandenbogerd)
- [Lwam B. Teklay](https://github.com/LwamB)

## 📦 Technologies

- `React`
- `Javascript`
- `CSS`
- `C#`
- `.NET`
- `PostgreSQL`
- `Websockets`

## 🦄 Features

Here's what you can do with our anomaly display application:

- **View the anomaly page**: Here all the anomalies are located that are detected by the AI model.

- **View the assets page**: Here all the assets are located that are detected by the AI model.

- **View the statistics page**: Here we can see all the statistics of the anomalies.

- **Filter all anomalies, assets or statistics**: We can filter each page by solved, flagged, date, type, etc...

- **View details of an anomaly or asset**: When clicking on an anomaly or asset we can view more detailed information.

- **Add a reaction to an anomaly or asset**: Add a reaction to the anomaly is posible in the small text area.

- **Change the status of an anomaly or asset**: Changing the status of solved or flagged is also possible.

- **Real time updating**: When an anomaly get's send over we can view it change on the map instantly and we can see a small toast message.

## 👩🏽‍🍳 The Process

This is our final project in our bachelor education. We had to go to a real client with a real problem. In this team there were three Aplication development students, two cyber security students and one AI student.

First we had to go to the client and asked what their problem was. RideOnTrack in our case, had the problem that they had so much video footage of trains in Belgium that they don't know what to do with it. The footage is filmed with a camera on top of the train that looks at the traintracks. Also, they are running out of storage because they have so much footage.

Our job was to create an AI model that runs on that camera and when it picks up anomalies (like tree branches on the track) or assets (like traffic lights) our modal picks it up, sends a photo over to our server and you can view it in our front-end application.

We came up with an solution on how to do it best. We had free choice to choose what languages we used. Because this was a smaller project we went for react because the load time would be minimal and the use of javascript suited them best. As backend we chose .NET, written in C# because they are allready used to working with C++ that this change would be optimal for them.

Then we started. At first every education team in seperate groups. AI worked on the modal, CCS worked with installing a pipeline and making sure AWS is running, creating a S3 bucket, and we the application students started working on the basic front-end (with dummy data).

In week 2 I started and tried to bring the team together, we asked CCS with help over the fastAPI that should send data to the S3 bucket and back to our database. Tried to involve the AI student and asked where we should help. We had 3 application students and this job was not severaly focussed on the application part but more so on the AI and CCS part. I as teamlead helped CCS and AI the most. I had to make sure everything went according to plan and that we stayed on track.

In week 3 we started bringing the three stories together as one. Everything was up and running in AWS with a lot of struggles but we came there. The fastAPI that I wrote got implemented in the AI part so that when an anomaly got detected it got send to the S3 bucket and back to our database which updated the front-end.

We made some minor tweaks here and there and overal the project was complete.

## 📚 What I Learned

During this project, I've picked up important skills and a better understanding of complex ideas, which improved my logical thinking. Don't forget the use with Terraform, leading a team, AWS, github itself are also things that greatly increased during this time.

### 🧠 Brain:

- **Logical Thinking**: Working as a team lead and helping everyone from the team really tested my logical thinking. Not only did I have to help CCS with terraform and AWS, I also needed to be there for my friends that were having trouble with react. All around I tried to be there for everyone to the best of my abilities.

### 📏 Team coordination:

- **Working as a team**: Wokring as a team is very important, this project really helped me with leading a team. I do think I did a great job and so my team agrees. Did I did everything perfect? Probally not, but the important thing is, they trusted me as much as I trusted them.

-- **Communication**: Leading such a team is not an easy task which is why I though communication is key. Every day we did a stand-up meeting so I knew what everybody did, was doing and was going to do. Because of this I had a clear idea of what needed to be done and where I should help.

### ⌚ Time management:

- **Using scrum board**: Keeping track of all our tasks using a scrum board really made everything organised. For this project we used Trello.

### 📓 New knowledge:

- **React**: First time using react in a project, experience was good.
- **.NET API**: Second time making an API with .NET, was pretty straight forward, securing it with a key was new so glad I tried that.
- **FastAPI**: First time creating an API with pyhton. Glad it worked fast and reliable.
- **AWS**: First time using aws and helping to automate everything using terraform, dockerfiles and a pipline.
- **Terraform**: First time trying terraform. I did not do much here but got a small hang of the basics.
- **Docker**: I did had a basic knowledge of docker but in this project to automate everything I had to help a bit on the issues we got while creating the docker containers.

### 🎡 Security:

- **API Security**: Here I learned how to "secure" an api with and api key.

### 📈 Overall Growth:

This project really helped me understand the importance of teamwork. Leading a team as well as understanding the team, which is more important then anything. Also my ability to adapt and learn things quickly.

## 💭 How can it be improved?

- Better api security
- Implementing more features

## 🚦 Running the Project

To run the project in your local environment, follow these steps:

1. Clone the repository to your local machine.
2. Run `npm install` or `yarn` in the project directory to install the required dependencies.
3. Run `npm run start` or `yarn start` to get the project started.
4. Open [http://localhost:8000](http://localhost:8000) (or the address shown in your console) in your web browser to view the app.

## 🍿 Video

[https://www.youtube.com/watch?v=PX_gxbysHCE&t](https://www.youtube.com/watch?v=PX_gxbysHCE&t=3s)

https://github.com/JarneDirken/2024-React_Project/assets/90832359/15bdbc98-3ab1-4f1f-bfe6-2b636f9fbbf5

https://github.com/JarneDirken/2024-React_Project/assets/90832359/9567264e-8668-415a-a5e3-89e788d8d5d3

https://github.com/JarneDirken/2024-React_Project/assets/90832359/397e5c8a-f139-407c-a042-8756c50c1479


