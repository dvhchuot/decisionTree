import _ from 'lodash'

export const calculateEntropy = listClassCount => {
    const index = _.findIndex(listClassCount, i => i ===0)
    if (index >= 0) return 0
    const count = listClassCount.reduce((t, i) => t + i, 0)
    const entropy = listClassCount.reduce((t, i) => {
        const a = i / count * Math.log(i/ count)
        return t - a
    } ,0)
    return entropy
}
export const calculateCountOfArray = array => {
    const count = array.reduce((t, i) => t + i, 0)
    return count
}

export const calculateCountClass =  (data, output, category) => {
    const count  = []
    output.forEach(e => {
        const list = data.filter(i => {
            return i[category[category.length - 1]]===e
        })
        count.push(list.length)
    })
    return count
}