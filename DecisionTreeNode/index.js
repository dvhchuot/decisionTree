import { Node } from "./src/entity/Node";
import { calculateEntropy, calculateCountClass } from './src/common'
import { data, category, output } from './src/data'
import { ID3 } from "./src/entity/ID3";

import _ from 'lodash'
import lineReader from 'line-reader'

import express from 'express'


const app = express()

let indexLine = 0

let nData = []

let nCategory = []

let nOutput = []


lineReader.eachLine('train.txt', function (line, a) {
  
  if (indexLine === 0) {
    nOutput = line.trim().split(',')
  } else
    if (indexLine === 1) {
      nCategory = line.trim().split(',')
    }
    else {
      const newData = line.trim().split(',')
      nData.push(_.zipObject(nCategory, newData))
    }
  indexLine++
  if (a) start()
})


const start = () => {
  console.log("TCL: nOutput", nOutput)
  console.log("TCL: nCategory", nCategory)
  console.log("TCL: nData", nData)
  const count = calculateCountClass(nData, nOutput, nCategory)
  const id3 = new ID3(nCategory, [],nData, nOutput, count)
  id3.start()
}

// app.get('', (req, res) => {

//   res.send(`Hello !`)
// })

// app.listen(3000, () => { console.log('hello') })

// start()

// const node = new Node()
// node.c1 = 2
// console.log("TCL: node", node)