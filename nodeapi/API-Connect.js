const express = require('express');
const mysql = require('mysql');
const multer = require('multer');
const cors = require('cors');
const bodyParser = require('body-parser');

const app = express();
app.use(cors());
app.use(express.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());


const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'boardinghouse',
});

db.connect((err) => {
  if (err) throw err;
  console.log('Connected to MySQL database');
});


app.get('/account', (req, res) => {
  const {username,password }= req.query;
  const query = "SELECT * FROM `account` where username=? and password=?";

  db.query(query, [username, password], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
});

// Token(ID) verification middleware
const verifyToken = (req, res, next) => {
  const token = req.headers.authorization;

  if (!token) {
    return res.status(401).send({ error: 'No token provided' });
  }
  const userId = parseInt(token); // Assuming token is the user_id
  const query = 'SELECT * FROM account_information WHERE account_id = ?';
  db.query(query, [userId], (err, results) => {
    if (err) {
      return res.status(500).send({ error: 'Error verifying token' });
    }

    if (results.length === 0) {
      return res.status(401).send({ error: 'Invalid token' });
    }
    next();
  });
};

app.get('/bhtables', verifyToken, (req, res) => {
  const displayData = req.query.displayData; 
  let sqlQuery;
   if (displayData === "Student_Information") {
    sqlQuery = "SELECT * FROM `student_information` ";
  
  } else if (displayData === "RoomInformation") {
    sqlQuery = "SELECT * FROM `room_information`";
  
  } else if (displayData === "ReservationForm") {
    sqlQuery = "SELECT * FROM `reservation`";
 
  } else if (displayData === "MontlyPayment") {
    sqlQuery = "SELECT concat(`STUDENT_FIRST_NAME`,' ', `STUDENT_MIDDLE_NAME`,' ', `STUDENT_LAST_NAME`) as name,monthly_payment.PAYMENT,Date_Format(monthly_payment.DATE , '%d-%m-%Y') as 'Payment' FROM `student_information` INNER JOIN monthly_payment on monthly_payment.STUDENT_ID=student_information.STUDENT_ID";
 
  }  else {
    return res.status(400).send({ error: 'Invalid displayData value' });
  }
  db.query(sqlQuery, (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
  
});

app.get('/search', verifyToken, (req, res) => {
  let {displayData,searchData}=req.query;
  
  let sqlQuery;
  if (displayData === "Student_Information") {
    searchData=searchData+"%";
    sqlQuery = "SELECT * FROM `student_information` where  STUDENT_FIRST_NAME like ?";
  } 
  
  else {
    return res.status(400).send({ error: 'Invalid displayData value' });
  }
  db.query(sqlQuery,[searchData], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
});

app.delete('/bhdeletion', verifyToken, (req, res) => {
  const {id,tableName}= req.query;
  let sqlQuery;
  if (!id || isNaN(id) || !tableName) {
    res.status(400).send({ error: 'Invalid or missing Parameter' });
    return;
  }
  if(tableName==="Student_Information"){
    sqlQuery = "DELETE FROM `student_information` WHERE STUDENT_ID= ?";
  }
  else if(tableName==="RoomInformation"){
    sqlQuery = "DELETE FROM `room_information` WHERE ROOM_ID=?";
  }
  else if(tableName==="ReservationForm"){
    sqlQuery = "DELETE FROM `reservation` WHERE RESERVATION_ID=?";
  }
  
  db.query(sqlQuery, [id], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error' });
    } else {
      res.status(200).send({ message: 'Successfully deleted' });
    }
  });
});

app.put('/boardinghouse', verifyToken, (req, res) => {
  const id=req.query.id;
  const tableName=req.query.tableName;

  if ( !id || isNaN(id) || !tableName) {
    res.status(400).send({ error: "Missing parameter or id error" });
    return;
  }

  if(tableName==="RoomInformation"){
    const {roomnumber,occupancy} = req.query;
    if (!roomnumber|| !occupancy ) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query ="UPDATE `room_information` SET `ROOM_NUMBER`= ?,`OCCUPANCY`=? WHERE ROOM_ID= ?";
    db.query(query, [roomnumber, occupancy,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else{
    return res.status(400).send({ error: 'Invalid table name' });
  }
});

app.post('/boardinghouse', verifyToken, (req, res) => {
  const tableName=req.query.tableName;
  console.log(tableName);
  if(tableName==="Student_Information"){
    const {studentFirstName,studentMiddleName,studentLastName,birthdate,age,gender,address,contactNumber,emailAddress,parentName,parentAddress,parentContactNumber,roomID} = req.query;
    console.log(req.query);
    if (!studentFirstName || !studentMiddleName || !studentLastName || !birthdate || !age || !gender || !address || !contactNumber || !emailAddress || !parentName || !parentAddress || !parentContactNumber || !roomID) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `student_information`( `STUDENT_FIRST_NAME`, `STUDENT_MIDDLE_NAME`, `STUDENT_LAST_NAME`, `BIRTHDATE`, `AGE`, `GENDER`, `ADDRESS`, `CONTACT_NUMBER`, `EMAIL_ADDRESS`, `PARENT_NAME`, `PARENT_ADDRESS`, `PARENT_CONTACT_NUMBER`, `ROOM_ID=?";
    db.query(query, [studentId,studentFirstName, studentMiddleName,studentLastName,birthdate,age,gender,address,contactNumber,emailAddress,parentName,parentAddress,parentContactNumber,roomID], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="RoomInformation"){
    const {roomNumber,occupancy} = req.query;
    console.log(req.query);
    if (!roomNumber || !occupancy) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `room_information`( `ROOM_NUMBER`, `OCCUPANCY'=?";
    db.query(query, [roomNumber,occupancy], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Account Request"){
    const {name,username,password,dateCreated,roleId} = req.query;
    if (!name || !username || !password || !dateCreated || !roleId || isNaN(roleId)) {
      res.status(400).send({ error: "Missing parameter or role id error" });
      return;
    }
    const query = "INSERT INTO `account_request`(`Name`, `Username`, `Password`, `Date_Created`, `Role_ID`) VALUES (?,?,?,?,?)";
    db.query(query, [name,username,password,dateCreated,roleId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Beneficiaries"){
    const {residentId,benefitId,membershipDate,status} = req.query;
    if (!residentId || isNaN(residentId) || !benefitId || isNaN(benefitId) || !membershipDate || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `beneficiary`(`Resident_ID`, `Benefit_ID`, `Membership_Date`, `Status`) VALUES (?,?,?,?)";
    db.query(query, [residentId,benefitId,membershipDate,status], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Benefits"){
    const {benefitName,description,dateImplemented} = req.query;
    if (!benefitName || !description || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `benefits`(`Benefit_Name`,`Description`, `Date_Implemented`) VALUES (?,?,?)";
    db.query(query, [benefitName,description,dateImplemented], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Blood Pressure"){
    const {residentId} = req.query;
    if (!residentId || isNaN(residentId)) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `blood_pressure`(`Resident_ID`) VALUES (?)";
    db.query(query, [residentId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="BMI"){
    const {residentId} = req.query;
    if (!residentId || isNaN(residentId)) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `bmi_information`(`Resident_ID`) VALUES(?)";
    db.query(query, [residentId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Pregnancy"){
    const {residentId,monthsOfPregnancy,dateChecked} = req.query;
    if (!residentId || isNaN(residentId) || !monthsOfPregnancy || isNaN(monthsOfPregnancy) || !dateChecked) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `pregnancy_information`(`Resident_ID`, `Months_of_Pregnancy`, `Date_Checked`) VALUES (?,?,?)";
    db.query(query, [residentId,monthsOfPregnancy,dateChecked], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Vaccine"){
    const {vaccineName,vaccineDetail,dossageSequence,dateImplemented} = req.query;
    if (!vaccineName || isNaN(dossageSequence) || !vaccineDetail || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `vaccine`( `Vaccine_Name`, `Vaccine_Detail`, `Dossage_Sequence`, `Date_Implemented`) VALUES (?,?,?,?)";
    db.query(query, [vaccineName,vaccineDetail,dossageSequence,dateImplemented], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Vaccination"){
    const {residentId,vaccinationDate,vaccineId,vaccinationCount,status} = req.query;
    if (!residentId || isNaN(residentId) || !vaccinationDate || isNaN(vaccineId) || !vaccineId || !vaccinationCount || isNaN(vaccinationCount) || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `vaccination`( `Resident_ID`, `Vaccination_Date`, `Vaccine_ID`, `Vaccination_Count`, `Status`) VALUES (?,?,?,?,?)";
    db.query(query, [residentId,vaccinationDate,vaccineId,vaccinationCount,status], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else{
    return res.status(400).send({ error: 'Invalid table name' });
  }
});

app.listen(3000, () => {
  console.log('Server running on port 3000');
});
