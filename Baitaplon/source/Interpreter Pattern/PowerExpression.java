 public class PowerExpression implements Expression {
 
    private String expression;
 
    public PowerExpression(String expression) {
        this.expression = expression;
    }
 
    @Override
    public int interpret(InterpreterEngineContext context) {
        return context.pow(expression);
    }
}