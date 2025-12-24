package com.example.clear_all.HoangNam.Infrastructure;


import com.fasterxml.jackson.annotation.JsonInclude;

import java.io.Serializable;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@JsonInclude(JsonInclude.Include.NON_NULL)
public class MessageResponse  implements Serializable {
    private boolean success;
    private String code;
    private int httpStatusCode;
    private String title;
    private String message;
    private Object data;
    private int totalCount;
    private boolean isRedirect;
    private String redirecUrl;
    private Map<String, List<String>> errors;

    // Default constructor
    public MessageResponse() {
        this.success = true;
        this.httpStatusCode = 200;
        this.errors = new HashMap<>();
    }

    // Copy constructor
    public MessageResponse(MessageResponse obj) {
        this.success = obj.success;
        this.code = obj.code;
        this.httpStatusCode = obj.httpStatusCode;
        this.title = obj.title;
        this.message = obj.message;
        this.data = obj.data;
        this.totalCount = obj.totalCount;
        this.isRedirect = obj.isRedirect;
        this.redirecUrl = obj.redirecUrl;
        this.errors = obj.errors;
    }

    // Getters and setters
    public boolean isSuccess() {
        return success;
    }

    public void setSuccess(boolean success) {
        this.success = success;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public int getHttpStatusCode() {
        return httpStatusCode;
    }

    public void setHttpStatusCode(int httpStatusCode) {
        this.httpStatusCode = httpStatusCode;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Object getData() {
        return data;
    }

    public void setData(Object data) {
        this.data = data;
    }

    public int getTotalCount() {
        return totalCount;
    }

    public void setTotalCount(int totalCount) {
        this.totalCount = totalCount;
    }

    public boolean isRedirect() {
        return isRedirect;
    }

    public void setRedirect(boolean redirect) {
        isRedirect = redirect;
    }

    public String getRedirecUrl() {
        return redirecUrl;
    }

    public void setRedirecUrl(String redirecUrl) {
        this.redirecUrl = redirecUrl;
    }

    public Map<String, List<String>> getErrors() {
        return errors;
    }

    public void setErrors(Map<String, List<String>> errors) {
        this.errors = errors;
    }
}
