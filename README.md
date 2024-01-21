# ConUHacks 2024 - Concordia Prep International

Our submission for ConUHacks VIII.  

Unsure of what to cook with the scattered ingredients you have in your fridge and kitchen? With this app, you can plug in the ingredients you have, and the AI will recommended several dishes with their recipe. It's the perfect way to find use out of your leftovers, discovers new and unique meals, and practice your cooking skills!  

Meet the team:  
Taief Ahmed: [Personal Website](https://inxendere.github.io)  
Amro Atique: [LinkedIn](https://www.linkedin.com/in/amroatique/)  
Parsa Hejazi: [LinkedIn](https://www.linkedin.com/in/parsa-hejazi/)   
Han Lee: [LinkedIn](https://www.linkedin.com/in/hanleehl/)  

## Installation
Note: you have to put your own OpenAI api in the user folder.
In your user folder in C drive, create a folder and call it ```.openai```
In that folder, create a json called ```auth.json```
In there, fill in the following:
```
{
"api_key": "YOUR API KEY HERE",
"organization": "YOUR ORGANIZATION HERE"
}
```
If it does not work afterwards, that means you either don't have GPT-4 or your tokens have expired.
In either case, you need only carry out the small instruction as laid out in tthe ChatGPTController script starting at line 61.
```
request.Model = "gpt-4-1106-preview";

// comment or delete the line above and uncomment the line below 
// if you don't have gpt-4

// request.Model = "gpt-3.5-turbo";
```
Then you should be ready to build the Unity project and use.

