import { Node } from "./Node"

export class ID3 {
    constructor(attribute, remainingAttribute, listData, listClass, listClassCount) {
        this.attribute = attribute
        this.remainingAttribute = remainingAttribute
        this.listClass = listClass
        this.listData = listData
        this.listClassCount = listClassCount
        this.root = new Node()
    }
    start() {
        this.root.init(this.listClassCount, this.attribute, this.listData, this.listClass)
        this.root.run()
        this.root.print('root ->>')
    }
}