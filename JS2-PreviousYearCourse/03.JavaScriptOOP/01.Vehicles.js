var vehicles = (function () {
    var AFTERBURNER_STATE = Object.freeze({
        ON: 'on',
        OFF: 'off'
    });

    var SPIN_DIRECTION = Object.freeze({
        CLOCKWISE: 'clockwise',
        COUNTER_CLOCKWISE: 'counter-clockwise'
    });

    var AMPHIBIOUS_MODE = Object.freeze({
        LAND_MODE: 'land-mode',
        WATER_MODE: 'water-mode'
    });

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    };

    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Get acceleration can not be used from propulsion unit class.")
    };

    function Wheel(radius) {
        this.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);
    Wheel.prototype.getAcceleration = function () {
        var acceleration = 2 * Math.PI * this.radius;

        return acceleration;
    };

    function PropellingNozzle(power, afterburnerSwitch) {
        this.power = power;
        this.afterburnerSwitch = afterburnerSwitch;
    }

    PropellingNozzle.inherit(PropulsionUnit);
    PropellingNozzle.prototype.getAcceleration = function () {
        if (this.afterburnerSwitch == AFTERBURNER_STATE.ON) {
            return 2 * this.power;
        }
        else if (this.afterburnerSwitch == AFTERBURNER_STATE.OFF) {
            return this.power;
        }
    };

    function Propeller(finsCount, spinDirection) {
        this.finsCount = finsCount;
        this.spinDirection = spinDirection;
    }

    Propeller.inherit(PropulsionUnit);
    Propeller.prototype.getAcceleration = function () {
        if (this.spinDirection == SPIN_DIRECTION.COUNTER_CLOCKWISE) {
            return -this.finsCount;
        }
        else if (this.spinDirection == SPIN_DIRECTION.CLOCKWISE) {
            return this.finsCount;
        }
    };

    function Vehicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        var propulsionUnitsCount = this.propulsionUnits.length;

        for (var i = 0; i < propulsionUnitsCount; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    };

    function LandVehicle(speed, wheels) {
        Vehicle.call(this, speed, wheels);

        if (wheels.length != 4) {
            throw new RangeError("Land vehicle should have exactly 4 wheels");
        }
    }

    LandVehicle.inherit(Vehicle);

    function AirVehicle(speed, propellingNozzles) {
        Vehicle.call(this, speed, propellingNozzles);

        if (propellingNozzles.length != 1) {
            throw new RangeError("air vehicle should have exactly 1 propelling nozzle");
        }
    }

    AirVehicle.inherit(Vehicle);
    AirVehicle.prototype.switchAfterburnersMode = function () {
        var propulsionUnitsCount = this.propulsionUnits.length;

        for (var i = 0; i < propulsionUnitsCount; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                if (this.propulsionUnits[i].afterburnerSwitch == AFTERBURNER_STATE.ON) {
                    this.propulsionUnits[i].afterburnerSwitch = AFTERBURNER_STATE.OFF;
                }
                else {
                    this.propulsionUnits[i].afterburnerSwitch = AFTERBURNER_STATE.ON;
                }
            }
        }
    };

    function WaterVehicle(speed, propellersCount) {
        Vehicle.call(this, speed, propellersCount);
    }

    WaterVehicle.inherit(Vehicle);
    WaterVehicle.prototype.switchSpinDirection = function () {
        var propulsionUnitsCount = this.propulsionUnits.length;

        for (var i = 0; i < propulsionUnitsCount; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                if (this.propulsionUnits[i].spinDirection == SPIN_DIRECTION.CLOCKWISE) {
                    this.propulsionUnits[i].spinDirection = SPIN_DIRECTION.COUNTER_CLOCKWISE
                }
                else {
                    this.propulsionUnits[i].spinDirection = SPIN_DIRECTION.CLOCKWISE
                }
            }
        }
    };

    function AmphibiousVehicle(speed, propellers, wheels, mode) {
        var wheelsCount = wheels.length;
        var propellersCount = propellers.length;
        var propulsionUnits = [];

        for (var i = 0; i < wheelsCount; i++) {
            propulsionUnits.push(wheels[i]);
        }

        for (var j = 0; j < propellersCount; j++) {
            propulsionUnits.push(propellers[j]);
        }
        Vehicle.call(this, speed, propulsionUnits);
        this.mode = mode;
    }

    AmphibiousVehicle.inherit(WaterVehicle);
    AmphibiousVehicle.prototype.switchMode = function () {
        if (this.mode == AMPHIBIOUS_MODE.WATER_MODE) {
            this.mode = AMPHIBIOUS_MODE.LAND_MODE;
        }
        else {
            this.mode = AMPHIBIOUS_MODE.WATER_MODE;
        }
    };
    AmphibiousVehicle.prototype.accelerate = function () {
        var propulsionUnitsCount = this.propulsionUnits.length;

        if (this.mode == AMPHIBIOUS_MODE.WATER_MODE) {
            for (var i = 0; i < propulsionUnitsCount; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
        else {
            for (var i = 0; i < propulsionUnitsCount; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    };

    return {
        AfterburnerState: AFTERBURNER_STATE,
        SpinDirection: SPIN_DIRECTION,
        AmphibiousMode: AMPHIBIOUS_MODE,
        Wheel: Wheel,
        Propeller: Propeller,
        PropellingNozzle: PropellingNozzle,
        WaterVehicle: WaterVehicle,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        AmphibiousVehicle: AmphibiousVehicle
    };
}());

