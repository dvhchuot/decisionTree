import _ from 'lodash'
import { calculateCountOfArray, calculateEntropy, calculateCountClass } from "../common"

export class Node {

    constructor() {
        this.entropy = undefined
        this.dataTraning = undefined
        this.dataCount = 0
        this.isLeaf = false
        this.children = []
        this.name = undefined
        this.value = undefined
        this.attributeIndex = undefined
        this.attributeName = undefined
        this.className = undefined
        this.classIndex = undefined
        this.listClassCount = []
        this.listClass = []
        this.listAttribute = []
    }
    init(a, attribute, listData, listClass) {
        const listClassCount = calculateCountClass(listData, listClass, attribute)
        const count = calculateCountOfArray(listClassCount)
        this.dataCount = count 
        const entropy = calculateEntropy(listClassCount)
        this.entropy = entropy
        this.listAttribute = attribute
        this.listClass = listClass
        this.listClassCount = listClassCount
        this.dataTraning = listData
        const index = listClassCount.findIndex(i => i === this.dataCount)
        if (index >=0 ) {
            this.isLeaf = true
            this.className = listClass[index]
        }
    }
    run() {
        if (this.isLeaf) return
        let max = -1
        this.listAttribute.slice(0, this.listAttribute.length - 1).map(e => {
            const newA = this.dataTraning.reduce((t, i) => {
                if (t[i[e]] === undefined) t[i[e]] = 1
                else t[i[e]]++
                return t
            }, {})
            const key = _.keys(newA)

            const children = key.reduce((t, i) => {
                const node = new Node()
                const data = this.dataTraning.filter(item => item[e] === i )
                const attribute = this.listAttribute.filter(f => f !== e)
                node.init(undefined,attribute, data, this.listClass)
                node.name = e
                node.value = i
                return [...t, node]
            }, [])
            const gain = children.reduce((t , c) => {
                return t - c.entropy * c.dataCount / this.dataCount
            }, this.entropy)
            if (gain > max) {
                max = gain
                this.children = children
            }
        })
        this.children.map(e => {
            e.run()
        })
    }
    print(s) {
        let newS = (this.name && this.value) ? s + ` ${this.name} = ${this.value} ` : s
        if(this.isLeaf) {
            newS += `--> ${this.className}`
            console.log(newS)
        }
        else {
            newS += (this.name && this.value) ? '+' : ''
            this.children.map(e => {
                e.print(newS)
            })
        }
    }
}