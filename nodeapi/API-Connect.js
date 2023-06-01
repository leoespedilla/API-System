const express = require ('express');
const mysql = require('mysql');
const multer = require('multer');
const cors = require('cors');
const bodyParser = require('body-parser');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

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


app.post('/account', (req, res) => {
  const {username,password }= req.query;
  console.log(req.query);
    if (!username || !password) {
      res.status(400).send({ error: 'Missing username or password' });
      return;
    }
  const query= "SELECT * FROM `account` where username=? ";
  db.query(query, [username], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
      return;
    }
    if (result.length === 0) {
      res.status(401).send({ error: 'Invalid credentials' });
      return;
    }
    const hashedPassword = result[0].password;
    bcrypt.compare(password, hashedPassword, (err, passwordMatch) => {
      if (err) {
        res.status(500).send({ error: 'Error logging in' });
        return;
      }

      if (passwordMatch) {
        res.status(200).send(result);
      } else {
        res.status(401).send({ error: 'Invalid password' });
      }
    });
  });
});

/// Generate a random secret key
const SECRET_KEY ='00881166jamd';
// Token verification middleware
const verifyToken = (req, res, next) => {
  const token = req.headers.authorization;
  
  if (!token) {
    return res.status(401).send({ error: 'No token provided' });
  }

  jwt.verify(token, SECRET_KEY, (err, decoded) => {
    if (err) {
      return res.status(401).send({ error: 'Invalid token' });
    }
    next();
  });
};


// Create account endpoint
app.post('/create-account', (req, res) => {
  const { Username, Password } = req.query;

  if (!Username || !Password ) {
    res.status(400).send({ error: 'Missing parameter or role ID error' });
    return;
  }

  const token = jwt.sign({ Username }, SECRET_KEY); // Generate JWT token

  bcrypt.hash(Password, 10, (err, hashedPassword) => {
    if (err) {
      console.error('Error hashing password:', err);
      res.status(500).send({ error: 'Error creating account' });
      return;
    }

    const query =
      'INSERT INTO `account`( `username`, `password`, `token`) VALUES (?,?,?)';

    db.query(query, [Username, hashedPassword, token], (err, result) => {
      if (err) {
        console.error('Error creating account:', err);
        res.status(500).send({ error: 'Error creating account' });
      } else {
        res.status(200).send({ message: 'Account created successfully' });
      }
    });
  });
});

// Create account endpoint
app.put('/update-account',verifyToken, (req, res) => {
  const { Name, Username, Password, Date_Updated, oldToken} = req.query;
  console.log(req.query);
  if (!Name || !Username || !Password || !Date_Updated ) {
    res.status(400).send({ error: 'Missing parameter or role ID error' });
    return;
  }

  const token = jwt.sign({ Username }, SECRET_KEY); // Generate JWT token

  bcrypt.hash(Password, 10, (err, hashedPassword) => {
    if (err) {
      console.error('Error hashing password:', err);
      res.status(500).send({ error: 'Error creating account' });
      return;
    }

    const query =
      'UPDATE accounts SET Name=?, Username= ?, Password=?, Date_Updated=?,token=? WHERE token=?';

    db.query(query, [Name, Username, hashedPassword, Date_Updated,token, oldToken], (err, result) => {
      if (err) {
        console.error('Error creating account:', err);
        res.status(500).send({ error: 'Error creating account' });
      } else {
        res.status(200).send({ message: 'Account updated successfully' });
      }
    });
  });
});

app.get('/bhtables', verifyToken, (req, res) => {
  const displayData = req.query.displayData; 
  let sqlQuery;
   if (displayData === "Student_Information") {
    sqlQuery = "SELECT * FROM `student_information` ";
  
  } else if (displayData === "RoomInformation") {
    sqlQuery = "SELECT * FROM `room_information`";
  
  } else if (displayData === "ReservationForm") {
    sqlQuery = "SELECT * FROM `reservation`";
 
  }else if (displayData === "ROOM_NUMBER") {
    sqlQuery = "SELECT ROOM_NUMBER, ROOM_ID FROM room_information";
 
  }else if (displayData === "name") {
    sqlQuery = "SELECT concat(`STUDENT_FIRST_NAME`,' ', `STUDENT_MIDDLE_NAME`,' ', `STUDENT_LAST_NAME`) as name, STUDENT_ID FROM `student_information`";
 
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
  let {searchData}=req.query;
  let sqlQuery;
    searchData=searchData+"%";
    sqlQuery = "SELECT * FROM `student_information` where  STUDENT_FIRST_NAME like ?";
  
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
  if ( !id || isNaN(id) ) {
    res.status(400).send({ error: "Missing parameter or id error" });
    return;
  }
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
});

app.post('/bhinsert', verifyToken, (req, res) => {
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
    const query = "INSERT INTO `room_information`( `ROOM_NUMBER`, `OCCUPANCY`) VALUES (?,?)";
    db.query(query, [roomNumber,occupancy], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="monthly_payment"){
    const {STUDENT_ID,PAYMENT,DATE} = req.query;
    console.log(req.query);
    if (!STUDENT_ID || !PAYMENT) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `monthly_payment`( `STUDENT_ID`, `PAYMENT`, `DATE`) VALUES (?,?,?)";
    db.query(query, [STUDENT_ID,PAYMENT,DATE], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="reservation"){
    const {STUDENT_NAME,RESERVATION_DATE,ADVANCE_PAYMENT} = req.query;
    console.log(req.query);
    if (!STUDENT_NAME || !ADVANCE_PAYMENT) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `reservation`( `STUDENT_NAME`, `RESERVATION_DATE`, `ADVANCE_PAYMENT`) VALUES  (?,?,?)";
    db.query(query, [STUDENT_NAME,RESERVATION_DATE,ADVANCE_PAYMENT], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
});
  

app.listen(3000, () => {
  console.log('Server running on port 3000');
});