import { OAuthModuleConfig } from 'angular-oauth2-oidc';
import { bootstrapConfig } from './bootstrap-config';

/**
 * ��Ȩģ������
 */
export const authModuleConfig: OAuthModuleConfig = {
    resourceServer: {
        allowedUrls: [bootstrapConfig.apiEndpointUrl],
        sendAccessToken: true
    }
};
