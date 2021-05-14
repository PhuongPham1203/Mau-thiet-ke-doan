public class SquareExpression implements Expression {
 
    private String expression;
 
    public SquareExpression(String expression) {
        this.expression = expression;
    }
 
    @Override
    public int interpret(InterpreterEngineContext context) {
        return context.sqrt(expression);
    }
}