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

app.get('/boardinghouse', verifyToken, (req, res) => {
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

app.delete('/boardinghouse', verifyToken, (req, res) => {
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

  if(tableName==="Resident Profile"){
    const {householdNumber,familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok} = req.query;
    if (!householdNumber || !familyNumber || !firstName || !middleName || !lastName || !birthDate || !Age || !birthPlace || !civilStatus || !civilStatus || !sex || !purok) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "UPDATE `resident_profile` SET `Household_Number`= ? ,`Family_Number`= ? ,`First_Name`= ? ,`Middle_Name`= ? ,`Last_Name`= ? ,`Extension_Name`= ? ,`Birth_Date`= ? ,`Age`= ? ,`Birth_Place`= ? ,`Civil_Status`= ? ,`Sex`= ? ,`Contact_Number`= ? ,`Purok`= ? WHERE resident_id= ?";
    db.query(query, [householdNumber, familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Beneficiaries"){
    const {benefitId,membershipDate,status} = req.query;
    if ( !benefitId || isNaN(benefitId) || !membershipDate || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `beneficiary` SET `Benefit_ID`=?,`Membership_Date`=?,`Status`= ? WHERE Beneficiary_ID= ?";
    db.query(query, [benefitId,membershipDate,status,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Benefits"){
    const {benefitName,description,dateImplemented} = req.query;
    if (!benefitName || !description || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `benefits` SET `Benefit_Name`= ?,`Description`= ?,`Date_Implemented`= ? WHERE Benefit_ID= ?";
    db.query(query, [benefitName,description,dateImplemented,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Blood Pressure"){
    const {systolic,diastolic,level,dateChecked} = req.query;
    if (!systolic || isNaN(systolic) || !diastolic || isNaN(diastolic) || !level || !dateChecked) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `blood_pressure` SET `systolic`= ?,`diastolic`= ?,`Level`= ?,`Date_Checked`= ? WHERE BP_ID= ?";
    db.query(query, [systolic,diastolic,level,dateChecked,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="BMI"){
    const {weight,height,status,dateUpdated} = req.query;
    if (!weight || isNaN(weight) || !height || isNaN(height) || !status || !dateUpdated ) {
      res.status(400).send({ error: "Missing parameter or error" });
      return;
    }
    const query = "UPDATE `bmi_information` SET `Weight`=?,`Height`=?,`Status`=?,`date_updated`=? where Resident_ID=?";
    db.query(query, [weight,height,status,dateUpdated,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Pregnancy"){
    const {monthsOfPregnancy,dateChecked} = req.query;
    if (!monthsOfPregnancy || isNaN(monthsOfPregnancy) || !dateChecked) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `pregnancy_information` SET `Months_of_Pregnancy`= ?,`Date_Checked`= ? WHERE Pregnancy_ID=?";
    db.query(query, [monthsOfPregnancy,dateChecked,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Vaccine"){
    const {vaccineName,vaccineDetail,dossageSequence,dateImplemented} = req.query;
    if (!vaccineName || isNaN(dossageSequence) || !vaccineDetail || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `vaccine` SET `Vaccine_Name`=?,`Vaccine_Detail`=?,`Dossage_Sequence`=?,`Date_Implemented`=? WHERE Vaccine_ID=?";
    db.query(query, [vaccineName,vaccineDetail,dossageSequence,dateImplemented,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Vaccination"){
    const {vaccinationDate,vaccineId,vaccinationCount,status} = req.query;
    if (!vaccinationDate || isNaN(vaccineId) || !vaccineId || !vaccinationCount || isNaN(vaccinationCount) || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `vaccination` SET `Vaccination_Date`=?,`Vaccine_ID`=?,`Vaccination_Count`=?,`Status`=? WHERE Vaccination_ID =?";
    db.query(query, [vaccinationDate,vaccineId,vaccinationCount,status,id], (err, result) => {
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

app.post('/bhwserver', verifyToken, (req, res) => {
  const tableName=req.query.tableName;
  console.log(tableName);
  if(tableName==="Resident Profile"){
    const {residentId,householdNumber,familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok} = req.query;
    console.log(req.query);
    if (!householdNumber || !familyNumber || !firstName || !middleName || !lastName || !birthDate || !Age || !birthPlace || !civilStatus || !civilStatus || !sex || !purok) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `resident_profile`VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    db.query(query, [residentId,householdNumber, familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Account Information"){
    const {accountId} = req.query;
    if (!accountId || isNaN(accountId)) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT into account_information(`Name`, `Username`, `Password`, `Date_Created`, `Role_ID`) SELECT `Name`, `Username`, `Password`, `Date_Created`, `Role_ID`  FROM account_request WHERE Request_ID=?";
    db.query(query, [accountId], (err, result) => {
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
