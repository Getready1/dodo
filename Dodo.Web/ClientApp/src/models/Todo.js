export class Todo {
  constructor(content, category, isCompleted = false) {
    this.content = content
    this.category = category
    this.isCompleted = isCompleted
  }
}
