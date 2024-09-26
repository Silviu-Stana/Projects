import express from 'express'
import bodyParser from 'body-parser'
import pg from 'pg'

const db = new pg.Client({
        user: 'postgres',
        password: 'sealpassword',
        host: 'localhost',
        port: '5432',
        database: 'secrets',
})

db.connect()

const app = express()
const port = 3000

app.use(bodyParser.urlencoded({ extended: true }))
app.use(express.static('public'))

app.get('/', (req, res) => {
        res.render('home.ejs')
})

app.get('/login', (req, res) => {
        res.render('login.ejs')
})

app.get('/register', (req, res) => {
        res.render('register.ejs')
})

app.post('/register', async (req, res) => {
        const email = req.body.username
        const password = req.body.password

        const existingAccounts = await db.query('SELECT email, password FROM users WHERE email=$1', [email])

        //If account email already exists.
        if (existingAccounts.rowCount > 0) {
                res.send('Email already registered.')
        } else if (password.length < 6) {
                res.send('password <6 characters, too short')
        } else if (existingAccounts.rowCount === 0) {
                const register = await db.query('INSERT INTO users(email, password) VALUES ($1, $2)', [email, password])
                res.render('secrets.ejs')
        }
})

app.post('/login', async (req, res) => {
        const email = req.body.username
        const password = req.body.password

        try {
                const existingAccounts = await db.query('SELECT email, password FROM users WHERE email=$1', [email])

                if (existingAccounts.rowCount > 0) {
                        let storedPassword = existingAccounts.rows[0].password
                        if (password === storedPassword) res.render('secrets.ejs')
                        else {
                                res.send('wrong password')
                        }
                } else {
                        res.send('email does not exist')
                }
        } catch (error) {
                console.error(error)
        }
})

app.listen(port, () => {
        console.log(`Server running on port ${port}`)
})
