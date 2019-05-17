import './TodoItem.css'
import React from 'react'
import { Button, Checkbox } from 'semantic-ui-react'

export default function TodoItem(props) {
  return (
    <div className="todo-item">
      <Checkbox label={props.content} checked={props.isCompleted} onChange={() => props.markCompleted(props.id)} />
      <Button icon="remove" size="mini" onClick={() => props.deleteTodoItem(props.id)} color="red" />
    </div>
  )
}
