export interface PageResult<T> {
    items: T[]
    hasNextPage?: boolean
    hasPreviousPage?: boolean
    totalCount: number
}
