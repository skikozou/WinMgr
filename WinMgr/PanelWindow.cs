using System;
using System.Drawing;
using System.Windows.Forms;

public class ResizableRectangle : Control
{
	public event EventHandler SizeChanged;

	private bool isDragging;
	private bool isResizing;
	private Point lastMousePosition;
	private Rectangle resizeRectangle;

	private const int handleSize = 10;
	private enum DragHandle
	{
		None, TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left
	}
	private DragHandle currentHandle;

	public ResizableRectangle()
	{
		this.BackColor = Color.Blue;
		this.Cursor = Cursors.Default;
		this.Size = new Size(100, 100);
		this.resizeRectangle = new Rectangle(this.Width - handleSize, this.Height - handleSize, handleSize, handleSize);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (currentHandle != DragHandle.None)
		{
			isResizing = true;
			lastMousePosition = e.Location;
		}
		else
		{
			isDragging = true;
			lastMousePosition = e.Location;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);

		if (isDragging)
		{
			this.Left += e.X - lastMousePosition.X;
			this.Top += e.Y - lastMousePosition.Y;
		}
		else if (isResizing)
		{
			ResizeControl(e.Location);
		}
		else
		{
			UpdateCursor(e.Location);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		if (isDragging || isResizing)
		{
			OnSizeChanged(EventArgs.Empty);
		}
		isDragging = false;
		isResizing = false;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using (Brush brush = new SolidBrush(Color.Red))
		{
			e.Graphics.FillRectangle(brush, resizeRectangle);
		}
	}

	private void ResizeControl(Point mousePosition)
	{
		int widthChange = mousePosition.X - lastMousePosition.X;
		int heightChange = mousePosition.Y - lastMousePosition.Y;

		switch (currentHandle)
		{
			case DragHandle.TopLeft:
				this.Left += widthChange;
				this.Top += heightChange;
				this.Width -= widthChange;
				this.Height -= heightChange;
				break;
			case DragHandle.Top:
				this.Top += heightChange;
				this.Height -= heightChange;
				break;
			case DragHandle.TopRight:
				this.Top += heightChange;
				this.Width += widthChange;
				this.Height -= heightChange;
				break;
			case DragHandle.Right:
				this.Width += widthChange;
				break;
			case DragHandle.BottomRight:
				this.Width += widthChange;
				this.Height += heightChange;
				break;
			case DragHandle.Bottom:
				this.Height += heightChange;
				break;
			case DragHandle.BottomLeft:
				this.Left += widthChange;
				this.Width -= widthChange;
				this.Height += heightChange;
				break;
			case DragHandle.Left:
				this.Left += widthChange;
				this.Width -= widthChange;
				break;
		}

		lastMousePosition = mousePosition;
		resizeRectangle = new Rectangle(this.Width - handleSize, this.Height - handleSize, handleSize, handleSize);
		this.Invalidate();
	}

	private void UpdateCursor(Point mousePosition)
	{
		currentHandle = GetDragHandle(mousePosition);
		switch (currentHandle)
		{
			case DragHandle.None:
				this.Cursor = Cursors.Default;
				break;
			case DragHandle.TopLeft:
			case DragHandle.BottomRight:
				this.Cursor = Cursors.SizeNWSE;
				break;
			case DragHandle.TopRight:
			case DragHandle.BottomLeft:
				this.Cursor = Cursors.SizeNESW;
				break;
			case DragHandle.Top:
			case DragHandle.Bottom:
				this.Cursor = Cursors.SizeNS;
				break;
			case DragHandle.Left:
			case DragHandle.Right:
				this.Cursor = Cursors.SizeWE;
				break;
		}
	}

	private DragHandle GetDragHandle(Point mousePosition)
	{
		if (new Rectangle(0, 0, handleSize, handleSize).Contains(mousePosition))
			return DragHandle.TopLeft;
		if (new Rectangle(this.Width - handleSize, 0, handleSize, handleSize).Contains(mousePosition))
			return DragHandle.TopRight;
		if (new Rectangle(0, this.Height - handleSize, handleSize, handleSize).Contains(mousePosition))
			return DragHandle.BottomLeft;
		if (new Rectangle(this.Width - handleSize, this.Height - handleSize, handleSize, handleSize).Contains(mousePosition))
			return DragHandle.BottomRight;
		if (new Rectangle(0, handleSize, handleSize, this.Height - handleSize * 2).Contains(mousePosition))
			return DragHandle.Left;
		if (new Rectangle(this.Width - handleSize, handleSize, handleSize, this.Height - handleSize * 2).Contains(mousePosition))
			return DragHandle.Right;
		if (new Rectangle(handleSize, 0, this.Width - handleSize * 2, handleSize).Contains(mousePosition))
			return DragHandle.Top;
		if (new Rectangle(handleSize, this.Height - handleSize, this.Width - handleSize * 2, handleSize).Contains(mousePosition))
			return DragHandle.Bottom;

		return DragHandle.None;
	}

	protected virtual void OnSizeChanged(EventArgs e)
	{
		SizeChanged?.Invoke(this, e);
	}
}
