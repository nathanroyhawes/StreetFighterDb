## --- WELCOME TO SFdb! ---

**- Introduction -**
This is a CRUD Web API meant to store information about fighting game characters. Users are able to add both characters and their moves, change and update them, as well as delete them entirely. Please try adding your own characters!

**- Features -**
This project contains the following features:

1. The application a CRUD API
2. The application is asynchronous
3. The program queries the database using RAW SQL, and presents that information in an "AllRecords" GET.
4. Optional: I have added comments where I think the SOLID principles apply.

**- Instructions -**
This database comes pre-loaded with information. I am using characters from the game Street Fighter 2. Running the program will start an instance of Swagger in your web browser. There you can access, add, edit and, delete the information using the *GET, POST, PUT,* and *DELETE* sections. The program will create any and all ID's for the database. The next section contains an example character.

1. Add a character using the "*POST*" section, this only takes a string for "name". The program will create the ID's.
2. The program will return with confirmation the character has been added, along with a GUID.
3. Take the GUID that was generated and use it to add moves for your character in the "*POST*" section of the move controller.
5. When you are done you can review the list of all characters and their moves by going to the "*AllRecords*" section at the bottom.


**- Example -**
You can use the following as an example, or add your own characters and moves!
{
  "name": "M. Bison"
}

{
  "charId": "**GENERATED GUID HERE**",
  "moveName": "Psycho Crusher",
  "moveNotation": "HOLD BACK + P"
}

*Thank you for trying SFdb!*

--------------------------------

**- Fighting Game Notation -**
There are several ways to dipict the movements of a controller. I have chosen to represent those movements as abbreviations. A key is below.

| Abbreviation | Definition |
|---------| --------|
| U | UP |
| D | DOWN |
| B | BACK |
| F | FORWARD |
| UF | UP + FORWARD |
| UB | UP + BACK |
| DF | DOWN + FORWARD |
| DB | DOWN + BACK |
| QCF | QUARTER CIRCLE FORWARD - DOWN -> DOWN FORWARD -> FORWARD |
| QCB | QUARTER CIRCLE BACK - DOWN -> DOWN BACK -> BACK |
| 360 | ROTATE STICK 360 DEGREES |
| LP | LIGHT PUNCH |
| MP | MEDIUM PUNCH |
| HP | HEAVY PUNCH |
| LK | LIGHT KICK |
| MK | MEDIUM KICK |
| HK | HEAVY KICK |

