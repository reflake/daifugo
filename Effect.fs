module Effect

    open Entities
    
    let toggleEffect (effect : Effects) (effectFlags : Effects) = effectFlags ^^^ effect
        
    let hasEffect (effect : Effects) (effectFlags : Effects) = effectFlags.HasFlag effect