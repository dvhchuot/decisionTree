import { Node } from "./src/entity/Node";
import {calculateEntropy, calculateCountClass} from './src/common'
import {data, category, output} from './src/data'
import { ID3 } from "./src/entity/ID3";

import express from 'express'

const app = express()

const count = calculateCountClass(data, output, category)
console.log("TCL: count", count)

const start = () => {
    const id3 = new ID3(category, [],data, output, count)
    id3.start()
}

start()

app.get('', (req, res) => {
    
    res.send(`Hello !`)
  })
  
app.listen(3000, () => {console.log('hello')})
  

// const node = new Node()
// node.c1 = 2
// console.log("TCL: node", node)